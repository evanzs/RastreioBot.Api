using System.Collections.Generic;
using Newtonsoft.Json;

namespace RastreioBot.Api.Models.Correios
{
    public class Evento
    {
        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("hora")]
        public string Hora { get; set; }

        [JsonProperty("criacao")]
        public string Criacao { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("unidade")]
        public Unidade Unidade { get; set; }

        [JsonProperty("destino")]
        public List<Destino> Destino { get; set; }

        [JsonProperty("cepDestino")]
        public string CepDestino { get; set; }

        [JsonProperty("prazoGuarda")]
        public string PrazoGuarda { get; set; }

        [JsonProperty("diasUteis")]
        public string DiasUteis { get; set; }

        [JsonProperty("dataPostagem")]
        public string DataPostagem { get; set; }

        [JsonProperty("postagem")]
        public Postagem Postagem { get; set; }
    }
}