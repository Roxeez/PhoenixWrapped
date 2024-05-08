using Newtonsoft.Json;

namespace Phoenix.NET.Messaging.Combat;

public class Attack : Message
{
    [JsonProperty("monster_id")]
    public required long MonsterId { get; init; }
    
    public Attack()
    {
        Type = MessageType.Attack;
    }
}