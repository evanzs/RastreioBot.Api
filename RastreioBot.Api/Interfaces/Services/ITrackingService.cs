using System.Collections.Generic;
using System.Threading.Tasks;
using RastreioBot.Api.Models.Api.Response;
using RastreioBot.Api.Models.Api.Trackings;
using RastreioBot.Api.Models.Entities.Trackings;

namespace RastreioBot.Api.Interfaces
{
    public interface ITrackingService
    {
        Task<bool> InsertNewTrackingAsync(TrackingApi trackingApi);
        Task<bool> InsertNewTrackingListAsync(List<TrackingApi> trackingApiList);
        Task<TrackingRecordResponse> GetTrackingRecordByNumberAsync(string trackingNumber);
        Task<List<TrackingRecordResponse>> GetTrackingRecordListByChatIdAsync(string chatId);
        Task<List<TrackingRecordResponse>> GetTrackingRecordListAsync();
    }
}