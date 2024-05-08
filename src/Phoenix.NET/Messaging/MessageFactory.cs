using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Phoenix.NET.Messaging.Combat;
using Phoenix.NET.Messaging.Interaction;
using Phoenix.NET.Messaging.Movement;
using Phoenix.NET.Messaging.Packet;
using Phoenix.NET.Messaging.Query;

namespace Phoenix.NET.Messaging;

internal class MessageFactory
{
    private readonly Dictionary<MessageType, Type> mappings = new()
    {
        [MessageType.PacketReceived] = typeof(PacketReceived),
        [MessageType.PacketSend] = typeof(PacketSend),
        [MessageType.QueryPlayer] = typeof(QueryPlayer),
        [MessageType.QuerySkills] = typeof(QuerySkills),
        [MessageType.Attack] = typeof(Attack),
        [MessageType.Collect] = typeof(Collect),
        [MessageType.PlayerWalk] = typeof(PlayerWalk),
        [MessageType.PickUp] = typeof(PickUp)
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