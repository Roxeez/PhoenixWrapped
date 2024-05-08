using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Interaction;

public class PickUp : Message
{
    [JsonProperty("item_id")]
    public required long ItemId { get; init; }
    
    public PickUp()
    {
        Type = MessageType.PickUp;
    }
}