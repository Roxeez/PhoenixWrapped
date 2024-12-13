namespace PhoenixWrapped.Messaging.Bot;

public class StopBot : Message
{
    public StopBot()
    {
        Type = MessageType.StopBot;
    }
}