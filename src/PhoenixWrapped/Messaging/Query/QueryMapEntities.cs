using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Query;

public class QueryMapEntities : Message
{
    [JsonProperty("npcs")]
    public List<NpcInfo> Npcs { get; init; }
    
    [JsonProperty("monsters")]
    public List<NpcInfo> Monsters { get; init; }
    
    [JsonProperty("items")]
    public List<ItemInfo> Items { get; init; }
    
    [JsonProperty("players")]
    public List<PlayerInfo> Players { get; init; }
    
    public QueryMapEntities()
    {
        Type = MessageType.QueryMapEntities;
    }
}

public class PlayerInfo
{
    [JsonProperty("id")]
    public long Id { get; init; }
    
    [JsonProperty("name")]
    public string Name { get; init; }
    
    [JsonProperty("x")]
    public int X { get; init; }
    
    [JsonProperty("y")]
    public int Y { get; init; }
    
    [JsonProperty("level")]
    public int Level { get; init; }
    
    [JsonProperty("champion_level")]
    public int ChampionLevel { get; init; }
    
    [JsonProperty("hp_percent")]
    public int HpPercent { get; init; }
    
    [JsonProperty("mp_percent")]
    public int MpPercent { get; init; }
}

public class NpcInfo
{
    [JsonProperty("name")]
    public string Name { get; init; }
    
    [JsonProperty("id")]
    public long Id { get; init; }
    
    [JsonProperty("x")]
    public int X { get; init; }
    
    [JsonProperty("y")]
    public int Y { get; init; }
    
    [JsonProperty("vnum")]
    public int Vnum { get; init; }
    
    [JsonProperty("hp_percent")]
    public int HpPercent { get; init; }
    
    [JsonProperty("mp_percent")]
    public int MpPercent { get; init; }
}

public class ItemInfo
{
    [JsonProperty("name")]
    public string Name { get; init; }
    
    [JsonProperty("vnum")]
    public int Vnum { get; init; }
    
    [JsonProperty("x")]
    public int X { get; init; }
    
    [JsonProperty("y")]
    public int Y { get; init; }
    
    [JsonProperty("quantity")]
    public int Quantity { get; init; }
    
    [JsonProperty("owner_id")]
    public int OwnerId { get; init; }
    
    [JsonProperty("id")]
    public long Id { get; init; }
}