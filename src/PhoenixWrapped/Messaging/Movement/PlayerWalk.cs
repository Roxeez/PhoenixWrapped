﻿using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Movement;

public class PlayerWalk : Message
{
    [JsonProperty("x")] 
    public required int X { get; init; }
    
    [JsonProperty("y")]
    public required int Y { get; init; }
    
    public PlayerWalk()
    {
        Type = MessageType.PlayerWalk;
    }
}