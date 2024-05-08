using System.Net.Sockets;
using PhoenixWrapped.Messaging;

namespace PhoenixWrapped;

public class PhoenixClient : IDisposable
{
    private readonly TcpClient client;
    private readonly MessageFactory factory;
    private readonly Task task;
    private readonly CancellationTokenSource cts;
    
    public event Action<Message> MessageReceived;

    public PhoenixClient(int port)
    {
        this.client = new TcpClient("127.0.0.1", port);
        this.factory = new MessageFactory();
        this.cts = new CancellationTokenSource();
        this.task = Process();
    }

    public void SendMessage(Message message)
    {
        var stream = client.GetStream();
        var buffer = factory.CreateBuffer(message);
        
        stream.Write(buffer);
        stream.Flush();
    }

    private async Task Process()
    {
        var stream = client.GetStream();
        var tmp = new List<byte>();
        
        while (!cts.IsCancellationRequested)
        {
            try
            {
                var buffer = new byte[4096];
                var size = await stream.ReadAsync(buffer, cts.Token);
            
                Array.Resize(ref buffer, size);

                tmp.AddRange(buffer);
            
                var eof = Array.IndexOf<byte>(tmp.ToArray(), 0x01);
                while (eof != -1)
                {
                    var msg = tmp.Take(eof).ToArray();
                    var message = factory.CreateMessage(msg);
                
                    if (message is not null)
                    {
                        MessageReceived?.Invoke(message);
                    }
                
                    tmp = tmp.Skip(eof + 1).ToList();
                    eof = Array.IndexOf<byte>(tmp.ToArray(), 0x01);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public void Dispose()
    {
        cts.Cancel();
        client.Dispose();
    }
}