namespace PhoenixWrapped.Messaging.Query;

public class QueryMapEntities : Message
{
    public QueryMapEntities()
    {
        Type = MessageType.QueryMapEntities;
    }
}