using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RastreioBot.Api.Models.Trackings
{
    [Table("tracking")]
    public class Tracking
    {
        [Column("tracking_code")]
        public string TrackingCode { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("delivered")]
        public bool Delivered { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("last_update")]
        public DateTime LastUpdate { get; set; }
    }
}