using System.Threading.Tasks;
using RastreioBot.Api.Models.Trackings;

namespace RastreioBot.Api.Interfaces
{
    public interface ITrackingRepository
    {
        Task<Tracking> GetTrackingByNumber(string trackingNumber);
        Task<Tracking> AddTracking(Tracking tracking);
    }
}