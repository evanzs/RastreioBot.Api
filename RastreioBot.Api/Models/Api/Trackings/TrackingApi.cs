using System.ComponentModel.DataAnnotations;

namespace RastreioBot.Api.Models.Api.Trackings
{
    public class TrackingApi
    {
        [Required(ErrorMessage = "Tracking number is required!")]
        [MaxLength(13)]
        public string TrackingNumber { get; set; }
        public string Description { get; set; }
    }
}