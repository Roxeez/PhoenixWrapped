using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Interaction;

public class Collect : Message
{
    [JsonProperty("npc_id")]
    public required long NpcId { get; init; }
    
    public Collect()
    {
        Type = MessageType.Collect;
    }
}