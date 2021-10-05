using System.Collections.Generic;
using System.Threading.Tasks;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Models.Api.Response;
using RastreioBot.Api.Models.Api.Trackings;
using RastreioBot.Api.Models.Entities.Trackings;
using RastreioBot.Api.Utils;

namespace RastreioBot.Api.Services
{
    public class TrackingService : ITrackingService
    {
        private readonly ITrackingRepository _repository;
        private readonly IUnitOfWork _uow;

        public TrackingService(ITrackingRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<TrackingRecordResponse> GetTrackingRecordAsync(string trackingNumber)
        {
            var tracking = await _repository.GetTrackingByNumber(trackingNumber);

            if (tracking.IsNull())
                return null;

            return tracking.ToResponse();
        }

        public async Task<List<TrackingRecordResponse>> GetTrackingRecordListAsync()
        {
            var trackings = await _repository.GetTrackingList();

            if (trackings.IsNullOrEmpty())
                return null;

            return trackings.ToResponse();
        }

        public async Task<bool> InsertNewTrackingAsync(TrackingApi trackingApi)
        {
            try
            {
                var tracking = trackingApi.ToEntity();

                await _repository.AddTracking(tracking);
                await _uow.Commit();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> InsertNewTrackingListAsync(List<TrackingApi> trackingApiList)
        {
            try
            {
                var trackings = trackingApiList.ToEntity();

                await _repository.AddTrackingList(trackings);
                await _uow.Commit();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}