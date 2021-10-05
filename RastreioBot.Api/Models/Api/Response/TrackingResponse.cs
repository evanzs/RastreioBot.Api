using System;
using System.Collections.Generic;

namespace RastreioBot.Api.Models.Api.Response
{
    public class TrackingResponse
    {
        public TrackingResponse(string trackingNumber, string description, List<Event> events)
        {
            TrackingNumber = trackingNumber;
            Description = description;
            Events = events;
        }

        public string TrackingNumber { get; private set; }
        public string Description { get; private set; }
        public List<Event> Events { get; set; }
    }

    public class Event
    {
        public Event(DateTime date, string description, string unityLocal, string unityType, string unityCity, string unityState, string destinyLocal, string destinyCity, string destinyState)
        {
            Date = date;
            Description = description;
            UnityLocal = unityLocal;
            UnityType = unityType;
            UnityCity = unityCity;
            UnityState = unityState;
            DestinyLocal = destinyLocal;
            DestinyCity = destinyCity;
            DestinyState = destinyState;
        }

        public Event(DateTime date, string description, string unityLocal, string unityType, string unityCity, string unityState)
        {
            Date = date;
            Description = description;
            UnityLocal = unityLocal;
            UnityType = unityType;
            UnityCity = unityCity;
            UnityState = unityState;
            DestinyLocal = string.Empty;
            DestinyCity = string.Empty;
            DestinyState = string.Empty;
        }

        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public string UnityLocal { get; private set; }
        public string UnityType { get; private set; }
        public string UnityCity { get; private set; }
        public string UnityState { get; private set; }
        public string DestinyLocal { get; private set; }
        public string DestinyType { get; private set; }
        public string DestinyCity { get; private set; }
        public string DestinyState { get; private set; }
    }
}