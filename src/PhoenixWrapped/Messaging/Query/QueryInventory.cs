namespace PhoenixWrapped.Messaging.Query;

public class QueryInventory : Message
{
    public QueryInventory()
    {
        Type = MessageType.QueryInventory;
    }
}