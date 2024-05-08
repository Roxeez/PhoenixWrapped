using Newtonsoft.Json;

namespace Phoenix.NET.Messaging.Packet;

public class PacketReceived : Message
{
    [JsonProperty("packet")]
    public required string Packet { get; init; }

    public PacketReceived()
    {
        Type = MessageType.PacketReceived;
    }
}