using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Interfaces.Services;
using RastreioBot.Api.Models.Api.Trackings;
using RastreioBot.Api.Models.Trackings;

namespace RastreioBot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                tracking = GetTrackingListAsync();
            else
                tracking = await Task.Factory.StartNew(() => _trackingService.GetTrackingAsync(tracking_number)).Result;

            if (tracking.IsNull())
                return NotFound();

            return Ok(tracking);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<TrackingApi> trackingApiList)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tracking = await Task.Factory.StartNew(() => _trackingService.InsertNewTrackingListAsync(trackingApiList)).Result;

            var statusCode = (int)HttpStatusCode.InternalServerError;

            if (tracking is List<TrackingApi>)
                statusCode = (int)HttpStatusCode.Created;

            return StatusCode(statusCode, tracking);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var trackings = GetTrackingListAsync().Result;

            if (trackings.IsNull())
                return NotFound();

            var trackingNumbers = (trackings as List<Tracking>).Select(t => t.TrackingNumber).ToList();

            var result = await Task.Factory.StartNew(() => _correiosService.GetTrackings(trackingNumbers)).Result;

            // if (tracking is List<TrackingApi>)
            //     statusCode = (int)HttpStatusCode.Created;

            return Ok(result);
        }

        private async Task<object> GetTrackingListAsync()
            => await Task.Factory.StartNew(() => _trackingService.GetTrackingListAsync()).Result;
    }
}
