using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RastreioBot.Api.Models.Trackings
{
    [Table("tracking")]
    public class Tracking : BaseEntity
    {
        [Column("tracking_number")]
        public string TrackingNumber { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("chat_id")]
        public string ChatId { get; set; }

        [Column("delivered")]
        public bool Delivered { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("last_update")]
        public DateTime? LastUpdate { get; set; }
    }
}