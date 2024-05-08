using Newtonsoft.Json;

namespace Phoenix.NET.Messaging.Query;

public class QuerySkills : Message
{
    [JsonProperty("skills")]
    public List<SkillInfo> Skills { get; init; }
    
    public QuerySkills()
    {
        Type = MessageType.QuerySkills;
    }
}

public class SkillInfo
{
    [JsonProperty("name")]
    public string Name { get; init; }
    
    [JsonProperty("vnum")]
    public int Vnum { get; init; }
    
    [JsonProperty("id")]
    public int Id { get; init; }
    
    [JsonProperty("range")]
    public int? Range { get; init; }
    
    [JsonProperty("area")]
    public int Area { get; init; }
    
    [JsonProperty("mana_cost")]
    public int ManaCost { get; init; }
    
    [JsonProperty("is_ready")]
    public bool IsReady { get; init; }
}