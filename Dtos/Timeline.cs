using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class Timeline
    {
        [JsonPropertyName("participantId")]
        public long ParticipantId { get; set; }

        [JsonPropertyName("creepsPerMinDeltas")]
        public Dictionary<string, double> CreepsPerMinDeltas { get; set; }

        [JsonPropertyName("xpPerMinDeltas")]
        public Dictionary<string, double> XpPerMinDeltas { get; set; }

        [JsonPropertyName("goldPerMinDeltas")]
        public Dictionary<string, double> GoldPerMinDeltas { get; set; }

        [JsonPropertyName("csDiffPerMinDeltas")]
        public Dictionary<string, double> CsDiffPerMinDeltas { get; set; }

        [JsonPropertyName("xpDiffPerMinDeltas")]
        public Dictionary<string, double> XpDiffPerMinDeltas { get; set; }

        [JsonPropertyName("damageTakenPerMinDeltas")]
        public Dictionary<string, double> DamageTakenPerMinDeltas { get; set; }

        [JsonPropertyName("damageTakenDiffPerMinDeltas")]
        public Dictionary<string, double> DamageTakenDiffPerMinDeltas { get; set; }

        [JsonPropertyName("role")]
        public Role Role { get; set; }

        [JsonPropertyName("lane")]
        public Lane Lane { get; set; }
    }
}
