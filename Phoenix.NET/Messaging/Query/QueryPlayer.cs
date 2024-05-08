namespace Phoenix.NET.Messaging.Query;

public class QueryPlayer : Message
{
    public QueryPlayer()
    {
        Type = MessageType.QueryPlayer;
    }
}