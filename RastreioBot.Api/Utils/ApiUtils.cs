using System;
using System.Collections.Generic;
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

        public static List<Tracking> ConvertTrackingApiListToTrackingList(this List<TrackingApi> trackingApiList)
        {
            var trackingList = new List<Tracking>();

            foreach (var track in trackingApiList)
            {
                trackingList.Add(new Tracking
                {
                    TrackingNumber = track.TrackingNumber,
                    Description = track.Description,
                    Delivered = false,
                    CreateDate = DateTime.Now,
                    LastUpdate = null
                });
            }

            return trackingList;
        }
    }
}