
namespace ACTVOT.common.Models
{
    using System;
    using Newtonsoft.Json;

    public class ActVote
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("actstar")]
        public DateTime Actstar { get; set; }

        [JsonProperty("endstar")]
        public DateTime Endstar { get; set; }

        [JsonProperty("imageUrl")]
        public object ImageUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("imageFullPath")]
        public object ImageFullPath { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Actstar}";
        }
    }
}

