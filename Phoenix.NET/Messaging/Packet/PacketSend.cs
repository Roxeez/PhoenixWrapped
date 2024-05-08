using Newtonsoft.Json;

namespace Phoenix.NET.Messaging.Packet;

public class PacketSend : Message
{
    [JsonProperty("packet")]
    public required string Packet { get; init; }

    public PacketSend()
    {
        Type = MessageType.PacketSend;
    }
}