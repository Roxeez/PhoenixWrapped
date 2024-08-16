using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Query;

public class QueryInventory : Message
{
    [JsonProperty("inventory", NullValueHandling = NullValueHandling.Ignore)]
    public InventoryInfo Inventory { get; init; }
    
    [JsonProperty("gold", NullValueHandling = NullValueHandling.Ignore)]
    public int Gold { get; init; }
    
    public QueryInventory()
    {
        Type = MessageType.QueryInventory;
    }
}

public class InventoryInfo
{
    [JsonProperty("equip", NullValueHandling = NullValueHandling.Ignore)]
    public List<InventoryItemInfo> Equip { get; init; }
    
    [JsonProperty("main", NullValueHandling = NullValueHandling.Ignore)]
    public List<InventoryItemInfo> Main { get; init; }
    
    [JsonProperty("etc", NullValueHandling = NullValueHandling.Ignore)]
    public List<InventoryItemInfo> Etc { get; init; }
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