namespace Phoenix.NET.Messaging.Query;

public class QueryMapEntities : Message
{
    public QueryMapEntities()
    {
        Type = MessageType.QueryMapEntities;
    }
}