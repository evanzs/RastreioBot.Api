using System.Collections.Generic;
using System.Threading.Tasks;
using RastreioBot.Api.Models.Entities.Trackings;

namespace RastreioBot.Api.Interfaces
{
    public interface ITrackingRepository
    {
        Task<Tracking> GetTrackingByNumber(string trackingNumber);
        Task<List<Tracking>> GetTrackingListByChatId(string chatId);
        Task<List<Tracking>> GetTrackingList();
        Task<Tracking> AddTracking(Tracking tracking);
        Task<List<Tracking>> AddTrackingList(List<Tracking> trackings);
    }
}