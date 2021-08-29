using System.Threading.Tasks;
using RastreioBot.Api.Models.Api.Trackings;
using RastreioBot.Api.Models.Trackings;

namespace RastreioBot.Api.Interfaces
{
    public interface ITrackingService
    {
        Task<Tracking> InsertNewTracking(TrackingApi trackingApi);
    }
}