namespace Phoenix.NET.Messaging.Query;

public class QueryInventory : Message
{
    public QueryInventory()
    {
        Type = MessageType.QueryInventory;
    }
}