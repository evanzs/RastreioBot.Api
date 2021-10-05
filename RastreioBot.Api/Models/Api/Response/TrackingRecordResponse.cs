using System;
using System.Text.Json.Serialization;

namespace RastreioBot.Api.Models.Api.Response
{
    public class TrackingRecordResponse
    {
        public TrackingRecordResponse(string trackingNumber, string description, string chatId, bool delivered, DateTime createDate, DateTime? lastUpdate)
        {
            TrackingNumber = trackingNumber;
            Description = description;
            ChatId = chatId;
            Delivered = delivered;
            CreateDate = createDate;
            LastUpdate = lastUpdate;
        }

        [JsonPropertyName("tracking_number")]
        public string TrackingNumber { get; private set; }

        [JsonPropertyName("description")]
        public string Description { get; private set; }

        [JsonPropertyName("chat_id")]
        public string ChatId { get; private set; }

        [JsonPropertyName("delivered")]
        public bool Delivered { get; private set; }

        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; private set; }

        [JsonPropertyName("last_update")]
        public DateTime? LastUpdate { get; private set; }
    }
}