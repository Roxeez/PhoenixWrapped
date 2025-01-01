using System.Text;
using Newtonsoft.Json;
using PhoenixWrapped.Messaging.Bot;
using PhoenixWrapped.Messaging.Combat;
using PhoenixWrapped.Messaging.Interaction;
using PhoenixWrapped.Messaging.Movement;
using PhoenixWrapped.Messaging.Packet;
using PhoenixWrapped.Messaging.Query;

namespace PhoenixWrapped.Messaging;

internal class MessageFactory
{
    private readonly Dictionary<MessageType, Type> mappings = new()
    {
        [MessageType.PacketReceived] = typeof(PacketReceived),
        [MessageType.PacketSend] = typeof(PacketSend),
        [MessageType.QueryPlayer] = typeof(QueryPlayer),
        [MessageType.QuerySkills] = typeof(QuerySkills),
        [MessageType.Attack] = typeof(Attack),
        [MessageType.PlayerSkill] = typeof(PlayerSkill),
        [MessageType.PartnerSkill] = typeof(PartnerSkill),
        [MessageType.PetSkill] = typeof(PetSkill),
        [MessageType.Collect] = typeof(Collect),
        [MessageType.PlayerWalk] = typeof(PlayerWalk),
        [MessageType.PetsWalk] = typeof(PetsWalk),
        [MessageType.PickUp] = typeof(PickUp),
        [MessageType.QueryMapEntities] = typeof(QueryMapEntities),
        [MessageType.QueryInventory] = typeof(QueryInventory),
        [MessageType.StartBot] = typeof(StartBot),
        [MessageType.StopBot] = typeof(StopBot),
        [MessageType.ContinueBot] = typeof(ContinueBot),
        [MessageType.TargetEntity] = typeof(TargetEntity)
    };
    
    public Message CreateMessage(byte[] buffer)
    {
        var json = Encoding.UTF8.GetString(buffer);
        if (string.IsNullOrEmpty(json))
        {
            throw new InvalidOperationException("Message is empty");
        }

        var message = JsonConvert.DeserializeObject<Message>(json);
        if (message is null)
        {
            throw new InvalidOperationException("Failed to deserialize json");
        }

        var type = mappings.GetValueOrDefault(message.Type);
        if (type is null)
        {
            return default;
        }

        var typedMessage = JsonConvert.DeserializeObject(json, type) as Message;
        if (typedMessage is null)
        {
            throw new InvalidOperationException($"Failed to deserialize json into {type}");
        }

        return typedMessage;
    }

    public byte[] CreateBuffer(Message message)
    {
        var json = JsonConvert.SerializeObject(message);
        if (string.IsNullOrEmpty(json))
        {
            throw new InvalidOperationException("Json is empty");
        }

        var buffer = Encoding.UTF8.GetBytes(json + "\u0001");

        return buffer;
    }
}