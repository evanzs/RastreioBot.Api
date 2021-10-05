using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RastreioBot.Api.Models.Api.Response;
using RastreioBot.Api.Models.Api.Trackings;
using RastreioBot.Api.Models.Correios;
using RastreioBot.Api.Models.Entities.Trackings;

namespace RastreioBot.Api.Utils
{
    public static class ApiUtils
    {
        public static Tracking ToEntity(this TrackingApi trackingApi)
        {
            return new Tracking
            {
                TrackingNumber = trackingApi.TrackingNumber,
                Description = trackingApi.Description,
                ChatId = trackingApi.ChatId,
                CreateDate = DateTime.Now,
                LastUpdate = null,
                Delivered = false
            };
        }

        public static List<Tracking> ToEntity(this List<TrackingApi> trackingApiList)
        {
            var trackingList = new List<Tracking>();

            foreach (var tracking in trackingApiList)
            {
                trackingList.Add(tracking.ToEntity());
            }

            return trackingList;
        }

        public static string ToXmlRequest(this List<string> trackingList)
        {
            using (var reader = new StreamReader(Directory.GetCurrentDirectory() + @"\Content\xml_file.xml"))
            {
                var trackingString = string.Empty;

                for (int i = 0; i < trackingList.Count; i++)
                {
                    trackingString += trackingList[i];
                }

                return reader.ReadToEnd().Replace("@tracking_code_list", trackingString);
            }
        }

        public static TrackingRecordResponse ToResponse(this Tracking tracking)
        {
            return new TrackingRecordResponse(tracking.TrackingNumber,
                                              tracking.Description,
                                              tracking.ChatId,
                                              tracking.Delivered,
                                              tracking.CreateDate,
                                              tracking.LastUpdate);
        }

        public static List<TrackingRecordResponse> ToResponse(this List<Tracking> trackings)
        {
            var trackingList = new List<TrackingRecordResponse>();

            foreach (var tracking in trackings)
            {
                trackingList.Add(tracking.ToResponse());
            }

            return trackingList;
        }

        private static List<TrackingResponse> OrderByDate(this List<TrackingResponse> trackingList)
        {
            foreach (var tracking in trackingList)
            {
                tracking.Events = tracking.Events.OrderByDescending(d => d.Date).ToList();
            }

            return trackingList;
        }
    }
}