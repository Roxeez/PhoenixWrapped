using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Phoenix.NET.Messaging.Packet;

namespace Phoenix.NET.Messaging;

public class MessageFactory
{
    private readonly Dictionary<MessageType, Type> mappings = new()
    {
        [MessageType.PacketReceived] = typeof(PacketReceived),
        [MessageType.PacketSend] = typeof(PacketSend)
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
            throw new InvalidOperationException($"Undefined message type: {message.Type}");
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