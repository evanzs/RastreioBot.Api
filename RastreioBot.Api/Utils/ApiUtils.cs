using System;
using RastreioBot.Api.Models.Api.Trackings;
using RastreioBot.Api.Models.Trackings;

namespace RastreioBot.Api.Utils
{
    public static class ApiUtils
    {
        public static Tracking ConvertTrackingApiToTracking(this TrackingApi trackingApi)
        {
            return new Tracking
            {
                TrackingNumber = trackingApi.TrackingNumber,
                Description = trackingApi.Description,
                Delivered = false,
                CreateDate = DateTime.Now,
                LastUpdate = null
            };
        }
    }
}