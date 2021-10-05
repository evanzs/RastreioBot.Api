using System.Collections.Generic;
using System.Threading.Tasks;
using RastreioBot.Api.Models.Api.Response;

namespace RastreioBot.Api.Interfaces.Services
{
    public interface ICorreiosService
    {
        Task<List<TrackingResponse>> GetTrackings(List<string> trackings);
    }
}