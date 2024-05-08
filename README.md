# Phoenix.NET
This library was made to easily interact with [Phoenix Bot API](https://github.com/hatz2/PhoenixAPI) using C#

### This library is still in development and is not yet feature complete.

## Installation
Using Package Manager
```shell
Install-Package Phoenix.NET
```

Using .NET CLI
```shell
dotnet add package Phoenix.NET
```
## Usage
```csharp
using Phoenix.NET;
using Phoenix.NET.Messaging.Packet;
using Phoenix.NET.Messaging.Query;

var client = PhoenixClientFactory.CreateByCharacterName("Rox");

client.MessageReceived += message =>
{
    switch (message)
    {
        case PacketSend snd:
            Console.WriteLine($"[SEND] {snd.Packet}");
            break;
        case PacketReceived rcv:
            Console.WriteLine($"[RECV] {rcv.Packet}");
            break;
        case QueryPlayer qry:
            Console.WriteLine($"[PLAYER] {qry.PlayerInfo.Name} / {qry.PlayerInfo.Level}");
            break;
    }
};

client.SendMessage(new QueryPlayer());
client.SendMessage(new PacketSend
{
    Packet = "my packet"
});
```