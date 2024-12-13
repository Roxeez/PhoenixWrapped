namespace PhoenixWrapped.Messaging.Bot;

public class StartBot : Message
{
    public StartBot()
    {
        Type = MessageType.StartBot;
    }
}