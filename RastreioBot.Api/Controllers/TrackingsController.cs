using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Models.Api.Trackings;

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
        public async Task<ActionResult> Get(string tracking_number)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tracking = await _service.GetTrackingAsync(tracking_number);

            if (tracking is null)
                return NotFound();

            return Ok(tracking);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TrackingApi trackingApi)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tracking = await _service.InsertNewTrackingAsync(trackingApi);

            if (tracking is null)
                return StatusCode((int)HttpStatusCode.InternalServerError);

            return CreatedAtAction(nameof(Get), new { tracking_number = tracking.TrackingNumber }, trackingApi);
        }
    }
}
