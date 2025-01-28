using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging;

public enum MessageType : byte
{
    PacketSend,
    PacketReceived,
    Attack,
    PlayerSkill,
    PlayerWalk,
    PetSkill,
    PartnerSkill,
    PetsWalk,
    PickUp,
    Collect,
    StartBot,
    StopBot,
    ContinueBot,
    QueryPlayer,
    QueryInventory,
    QuerySkills,
    QueryMapEntities,
    TargetEntity
}

public class Message
{
    [JsonProperty("type")]
    public MessageType Type { get; protected set; }

    public Message()
    {
        
    }

    public Message(MessageType type)
    {
        Type = type;
    }
}
