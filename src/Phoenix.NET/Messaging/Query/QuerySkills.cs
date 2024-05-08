namespace Phoenix.NET.Messaging.Query;

public class QuerySkills : Message
{
    public QuerySkills()
    {
        Type = MessageType.QuerySkills;
    }
}