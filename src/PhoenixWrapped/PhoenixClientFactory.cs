
using System.Diagnostics;
using PhoenixWrapped.Utility;

namespace PhoenixWrapped
{
    public class Window
    {
        public string Character { get; init; }
        public Process Process { get; init; }
        public int Port { get; init; }
    }

    public static class PhoenixClientFactory
    {
        public static IEnumerable<PhoenixClient> CreateAll()
        {
            var windows = GetWindows();

            var output = new List<PhoenixClient>();
            foreach (var window in windows)
            {
                output.Add(new PhoenixClient(window.Port));
            }

            return output;
        }
        public static PhoenixClient CreateByCharacterName(string name)
        {
            var windows = GetWindows();
            var matchingWindow = windows.FirstOrDefault(x => x.Character == name);
            if (matchingWindow is not null)
            {
                return new PhoenixClient(matchingWindow.Port);
            }

            throw new InvalidOperationException($"Failed to create client matching name {name}");
        }

        public static PhoenixClient CreateByPort(int port)
        {
            var windows = GetWindows();
            var matchingWindow = windows.FirstOrDefault(x => x.Port == port);
            if (matchingWindow is not null)
            {
                return new PhoenixClient(matchingWindow.Port);
            }
        
            throw new InvalidOperationException($"Failed to create client matching port {port}");
        }

        public static PhoenixClient CreateByProcessId(int processId)
        {
            var windows = GetWindows();
            var matchingWindow = windows.FirstOrDefault(x => x.Process.Id == processId);
            if (matchingWindow is not null)
            {
                return new PhoenixClient(matchingWindow.Port);
            }
        
            throw new InvalidOperationException($"Failed to create client process id {processId}");
        }

        public static IEnumerable<Window> GetWindows()
        {
            var processes = Process.GetProcessesByName("NostaleClientX");

            var output = new List<Window>();
            foreach (var process in processes)
            {
                var windows = WindowUtility.GetWindows(process);
                foreach (var window in windows)
                {
                    var title = WindowUtility.GetWindowTitle(window);
                    if (string.IsNullOrEmpty(title))
                    {
                        continue;
                    }

                    if (!title.Contains("Phoenix Bot"))
                    {
                        continue;
                    }

                    var characterName = title
                        .Split(' ')[2]
                        .Replace("]", "");

                    if (!int.TryParse(title[(title.IndexOf(':') + 1)..], out var port))
                    {
                        continue;
                    }

                    output.Add(new Window
                    {
                        Process = process,
                        Port = port,
                        Character = characterName
                    });
                }
            }
        
            return output;
        }
    }
}