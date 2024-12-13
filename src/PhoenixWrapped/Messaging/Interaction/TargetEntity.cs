using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Interaction;

public enum EntityType : byte
{
    Player = 1,
    Npc = 2,
    Monster = 3
}
public class TargetEntity : Message
{
    [JsonProperty("entity_type")]
    public required EntityType EntityType { get; init; }

    [JsonProperty("entity_id")]
    public required int EntityId { get; init; }

    public TargetEntity()
    {
        Type = MessageType.TargetEntity;
    }
}