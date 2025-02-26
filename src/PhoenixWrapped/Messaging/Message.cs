using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging;

public enum MessageType : byte
{
    PacketSend = 0,
    PacketReceived = 1,
    Attack = 2,
    PlayerSkill = 3,
    PlayerWalk = 4,
    PetSkill = 5,
    PartnerSkill = 6,
    PetsWalk = 7,
    PickUp = 8,
    Collect = 9,
    StartBot = 10,
    StopBot = 11,
    ContinueBot = 12,
    QueryPlayer = 16,
    QueryInventory = 17,
    QuerySkills = 18,
    QueryMapEntities = 19,
    TargetEntity = 20,
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
