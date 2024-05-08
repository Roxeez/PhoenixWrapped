namespace Phoenix.NET.Messaging.Interaction;

public class PickUp : Message
{
    public required long ItemId { get; init; }
    
    public PickUp()
    {
        Type = MessageType.PickUp;
    }
}