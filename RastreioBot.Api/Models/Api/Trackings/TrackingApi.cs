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
        public string Description { get; set; }
    }
}