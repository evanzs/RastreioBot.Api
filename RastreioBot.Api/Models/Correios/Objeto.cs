using System.Collections.Generic;
using Newtonsoft.Json;

namespace RastreioBot.Api.Models.Correios
{
    public class Objeto
    {
        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("sigla")]
        public string Sigla { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("categoria")]
        public string Categoria { get; set; }

        [JsonProperty("evento")]
        public List<Evento> Evento { get; set; }
    }
}