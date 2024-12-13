using Newtonsoft.Json;

namespace PhoenixWrapped.Messaging.Interaction
{
    public enum EntityType : byte
    {
        Player = 1,
        Npc = 2,
        Monster = 3
    }
    public class TargetEntity : Message
    {
        [JsonProperty("entity_type")]
        public EntityType EntityType { get; set; }

        [JsonProperty("entity_id")]
        public int EntityId { get; set; }

        public TargetEntity()
        {
            Type = MessageType.TargetEntity;
        }
    }
}