using System;
using RastreioBot.Api.Models.Api.Trackings;
using RastreioBot.Api.Models.Api.Users;
using RastreioBot.Api.Models.Trackings;
using RastreioBot.Api.Models.Users;

namespace RastreioBot.Api.Utils
{
    public static class ApiUtils
    {
        public static UserApi ConvertUserToUserApi(this User user)
        {
            return new UserApi
            {
                Name = user.Name,
                Token = user.UserToken
            };
        }

        public static User ConvertUserApiToUser(this UserApi user)
        {
            return new User
            {
                Name = user.Name,
                UserToken = user.Token
            };
        }

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