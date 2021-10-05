using System.Collections.Generic;
using Newtonsoft.Json;

namespace RastreioBot.Api.Models.Correios
{
    public class CorreiosResponse
    {
        [JsonProperty("versao")]
        public string Versao { get; set; }

        [JsonProperty("quantidade")]
        public string Quantidade { get; set; }

        [JsonProperty("pesquisa")]
        public string Pesquisa { get; set; }

        [JsonProperty("resultado")]
        public string Resultado { get; set; }

        [JsonProperty("objeto")]
        public List<Objeto> Objeto { get; set; }
    }
}