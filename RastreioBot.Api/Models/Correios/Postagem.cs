using Newtonsoft.Json;

namespace RastreioBot.Api.Models.Correios
{
    public class Postagem
    {
        [JsonProperty("cepdestino")]
        public string Cepdestino { get; set; }

        [JsonProperty("ar")]
        public string Ar { get; set; }

        [JsonProperty("mp")]
        public string Mp { get; set; }

        [JsonProperty("dh")]
        public string Dh { get; set; }

        [JsonProperty("peso")]
        public string Peso { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("dataprogramada")]
        public string Dataprogramada { get; set; }

        [JsonProperty("datapostagem")]
        public string Datapostagem { get; set; }

        [JsonProperty("prazotratamento")]
        public string Prazotratamento { get; set; }
    }
}