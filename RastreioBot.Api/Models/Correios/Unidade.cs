using Newtonsoft.Json;

namespace RastreioBot.Api.Models.Correios
{
    public class Unidade
    {
        [JsonProperty("local")]
        public string Local { get; set; }

        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("sto")]
        public string Sto { get; set; }

        [JsonProperty("tipounidade")]
        public string Tipounidade { get; set; }

        [JsonProperty("endereco")]
        public Endereco Endereco { get; set; }
    }
}