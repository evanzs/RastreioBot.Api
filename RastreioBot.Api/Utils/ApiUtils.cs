using System;
using System.Collections.Generic;
using System.IO;
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

        public static string ConvertTrackingSearchListToXml(this List<string> trackingList)
        {
            using (var reader = new StreamReader(Directory.GetCurrentDirectory() + @"\Content\xml.xml"))
            {
                var trackingString = string.Empty;

                for (int i = 0; i < trackingList.Count; i++)
                {
                    trackingString += trackingList[i];

                    if (!i.Equals(trackingList.Count))
                        trackingString += ",";
                }

                return reader.ReadToEnd().Replace("@tracking_code_list", trackingString);
            }
        }
    }
}