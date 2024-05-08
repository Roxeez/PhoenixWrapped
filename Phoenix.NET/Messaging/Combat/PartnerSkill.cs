using Newtonsoft.Json;

namespace Phoenix.NET.Messaging.Combat;

public class PartnerSkill : Message
{
    [JsonProperty("monster_id")]
    public required int MonsterId { get; init; }
    
    [JsonProperty("skill_id")]
    public required int SkillId { get; init; }
    
    public PartnerSkill()
    {
        Type = MessageType.PartnerSkill;
    }
}