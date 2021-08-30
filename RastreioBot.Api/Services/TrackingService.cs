using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Models.Api.Trackings;
using RastreioBot.Api.Models.Trackings;
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

        public async Task<Tracking> GetTrackingAsync(string trackingNumber)
        {
            return await _repository.GetTrackingByNumber(trackingNumber);
        }

        public async Task<List<Tracking>> GetTrackingListAsync()
        {
            return await _repository.GetTrackingList();
        }

        public async Task<object> InsertNewTrackingAsync(TrackingApi trackingApi)
        {
            try
            {
                var tracking = trackingApi.ConvertTrackingApiToTracking();

                await _repository.AddTracking(tracking);
                await _uow.Commit();

                return tracking;
            }
            catch (Exception ex)
            {
                return new
                {
                    message = "Ocorreu um erro ao adicionar o rastreamento.",
                    error = ex.Message
                };
            }

        }
    }
}