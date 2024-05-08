using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Combat;

public class PetSkill : Message
{
    [JsonProperty("monster_id")]
    public required int MonsterId { get; init; }
    
    [JsonProperty("skill_id")]
    public required int SkillId { get; init; }

    public PetSkill()
    {
        Type = MessageType.PetSkill;
    }
}