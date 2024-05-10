using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Query;

public class QueryInventory : Message
{
    [JsonProperty("equip")]
    public List<InventoryItemInfo> Equip { get; init; }
    
    [JsonProperty("main")]
    public List<InventoryItemInfo> Main { get; init; }
    
    [JsonProperty("etc")]
    public List<InventoryItemInfo> Etc { get; init; }
    
    [JsonProperty("gold")]
    public int Gold { get; init; }
    
    public QueryInventory()
    {
        Type = MessageType.QueryInventory;
    }
}

public class InventoryItemInfo
{
    [JsonProperty("quantity")]
    public int Quantity { get; init; }
    
    [JsonProperty("name")]
    public string Name { get; init; }
    
    [JsonProperty("slot")]
    public int Slot { get; init; }
    
    [JsonProperty("vnum")]
    public int Vnum { get; init; }
}