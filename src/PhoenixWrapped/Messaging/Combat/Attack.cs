using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Combat;

public class Attack : Message
{
    [JsonProperty("monster_id")]
    public required long MonsterId { get; init; }
    
    public Attack()
    {
        Type = MessageType.Attack;
    }
}