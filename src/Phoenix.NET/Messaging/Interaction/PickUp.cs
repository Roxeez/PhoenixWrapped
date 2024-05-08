using Newtonsoft.Json;

namespace Phoenix.NET.Messaging.Interaction;

public class PickUp : Message
{
    [JsonProperty("item_id")]
    public required long ItemId { get; init; }
    
    public PickUp()
    {
        Type = MessageType.PickUp;
    }
}