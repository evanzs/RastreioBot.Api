using System.Collections.Generic;
using System.Threading.Tasks;
using RastreioBot.Api.Models.Trackings;

namespace RastreioBot.Api.Interfaces
{
    public interface ITrackingRepository
    {
        Task<Tracking> GetTrackingByNumber(string trackingNumber);
        Task<List<Tracking>> GetTrackingList();
        Task<Tracking> AddTracking(Tracking tracking);
        Task<List<Tracking>> AddTrackingList(List<Tracking> trackings);
    }
}