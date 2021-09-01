using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RastreioBot.Api.Models.Api.Trackings
{
    public class TrackingApi
    {
        [Required(ErrorMessage = "Tracking number is required!")]
        [MaxLength(13)]
        [JsonPropertyName("tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonPropertyName("description")]
        [MaxLength(30)]
        public string Description { get; set; }

        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
    }
}