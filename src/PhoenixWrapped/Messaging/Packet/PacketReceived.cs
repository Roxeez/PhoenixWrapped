using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Packet;

public class PacketReceived : Message
{
    [JsonProperty("packet")]
    public required string Packet { get; init; }

    public PacketReceived()
    {
        Type = MessageType.PacketReceived;
    }
}