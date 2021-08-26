using Newtonsoft.Json;

namespace RastreioBot.Api.Models.Correios
{
    public class Destino
    {
        [JsonProperty("local")]
        public string Local { get; set; }

        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        // [JsonProperty("endereco")]
        // public Endereco Endereco { get; set; }
    }
}