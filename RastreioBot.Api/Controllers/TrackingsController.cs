using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Models.Api.Trackings;
using RastreioBot.Api.Models.Trackings;

namespace RastreioBot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackingsController : ControllerBase
    {
        private ITrackingService _service;

        public TrackingsController(ITrackingService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{tracking_number}")]
        public async Task<IActionResult> Get(string tracking_number)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tracking = await _service.GetTrackingAsync(tracking_number);

            if (tracking is null)
                return NotFound();

            return Ok(tracking);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TrackingApi trackingApi)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tracking = await _service.InsertNewTrackingAsync(trackingApi);

            var statusCode = (int)HttpStatusCode.Created;

            if (tracking is not Tracking)
                statusCode = (int)HttpStatusCode.InternalServerError;

            return StatusCode(statusCode, tracking);
        }
    }
}
