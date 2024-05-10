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

public class OwnPlayerInfo : PlayerInfo
{
    [JsonProperty("map_id")]
    public int MapId { get; init; }
    
    [JsonProperty("is_resting")]
    public bool IsResting { get; init; }
}