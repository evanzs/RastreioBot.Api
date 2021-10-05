using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Interfaces.Services;
using RastreioBot.Api.Models.Api.Response;
using RastreioBot.Api.Models.Api.Trackings;
using RastreioBot.Api.Models.Entities.Trackings;

namespace RastreioBot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/records")]
    public class TrackingsController : ControllerBase
    {
        private ITrackingService _trackingService;
        private ICorreiosService _correiosService;

        public TrackingsController(ITrackingService trackingService, ICorreiosService correiosService)
        {
            _trackingService = trackingService;
            _correiosService = correiosService;
        }

        [HttpGet]
        [Route("")]
        [Route("{tracking_number}")]
        public async Task<IActionResult> Get(string tracking_number = "")
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tracking = new object();

            if (tracking_number.IsNullOrWhiteSpace())
                tracking = await GetTrackingListAsync();
            else
                tracking = await _trackingService.GetTrackingRecordAsync(tracking_number);

            if (tracking.IsNull())
                return NotFound();

            return Ok(tracking);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] List<TrackingApi> trackingApiList)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tracking = await _trackingService.InsertNewTrackingListAsync(trackingApiList);

            if (tracking)
                return StatusCode(201);

            return StatusCode(500);
        }

        [HttpGet]
        [Route("searchall")]
        public async Task<IActionResult> SearchAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var trackings = await GetTrackingListAsync();

            if (trackings.IsNull())
                return NotFound();

            var trackingNumbers = trackings.Select(t => t.TrackingNumber).ToList();

            var result = await _correiosService.GetTrackings(trackingNumbers);

            return Ok(result);
        }

        private async Task<List<TrackingRecordResponse>> GetTrackingListAsync()
            => await _trackingService.GetTrackingRecordListAsync();
    }
}
