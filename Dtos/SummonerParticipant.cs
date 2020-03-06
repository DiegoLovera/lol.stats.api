using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lol.stats.api.Dtos
{
    public class SummonerParticipant
    {
        [JsonPropertyName("participant")]
        public Participant Participant { get; set; }

        [JsonPropertyName("participantIdentity")]
        public ParticipantIdentity ParticipantIdentity { get; set; }
    }
}
