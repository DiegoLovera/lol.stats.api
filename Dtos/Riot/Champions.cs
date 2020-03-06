using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos.Riot
{
    public partial class Champions
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("format")]
        public string Format { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string, Datum> Data { get; set; }
    }

    public partial class Datum
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("blurb")]
        public string Blurb { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("tags")]
        public string[] Tags { get; set; }

        [JsonPropertyName("partype")]
        public string Partype { get; set; }

        [JsonPropertyName("stats")]
        public Dictionary<string, double> Stats { get; set; }
    }

    public partial class Image
    {
        [JsonPropertyName("full")]
        public string Full { get; set; }

        [JsonPropertyName("sprite")]
        public string Sprite { get; set; }

        [JsonPropertyName("group")]
        public string Group { get; set; }

        [JsonPropertyName("x")]
        public long X { get; set; }

        [JsonPropertyName("y")]
        public long Y { get; set; }

        [JsonPropertyName("w")]
        public long W { get; set; }

        [JsonPropertyName("h")]
        public long H { get; set; }
    }

    public partial class Info
    {
        [JsonPropertyName("attack")]
        public long Attack { get; set; }

        [JsonPropertyName("defense")]
        public long Defense { get; set; }

        [JsonPropertyName("magic")]
        public long Magic { get; set; }

        [JsonPropertyName("difficulty")]
        public long Difficulty { get; set; }
    }
}
