using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Query;

public class QueryPlayer : Message
{
    [JsonProperty("player_info", NullValueHandling = NullValueHandling.Ignore)]
    public PlayerInfo PlayerInfo { get; init; }
    
    public QueryPlayer()
    {
        Type = MessageType.QueryPlayer;
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
    
    [JsonProperty("map_id")]
    public int MapId { get; init; }
    
    [JsonProperty("is_resting")]
    public bool IsResting { get; init; }
}