using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Packet;

public class PacketSend : Message
{
    [JsonProperty("packet")]
    public required string Packet { get; init; }

    public PacketSend()
    {
        Type = MessageType.PacketSend;
    }
}