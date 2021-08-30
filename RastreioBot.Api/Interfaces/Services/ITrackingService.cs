using System.Collections.Generic;
using System.Threading.Tasks;
using RastreioBot.Api.Models.Api.Trackings;
using RastreioBot.Api.Models.Trackings;

namespace RastreioBot.Api.Interfaces
{
    public interface ITrackingService
    {
        Task<object> InsertNewTrackingAsync(TrackingApi trackingApi);
        Task<Tracking> GetTrackingAsync(string trackingNumber);
        Task<List<Tracking>> GetTrackingListAsync();
    }
}