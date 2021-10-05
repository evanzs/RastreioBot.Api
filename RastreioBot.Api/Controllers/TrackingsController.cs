using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Interfaces.Services;
using RastreioBot.Api.Models.Api.Response;
using RastreioBot.Api.Models.Api.Trackings;

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
        [Route("records/chatid/{chat_id}")]
        public async Task<IActionResult> GetByChatId(string chat_id = "")
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tracking = new object();

            if (chat_id.IsNullOrEmpty())
                return BadRequest();

            tracking = await _trackingService.GetTrackingRecordListByChatIdAsync(chat_id);

            if (tracking.IsNull())
                return NotFound();

            return Ok(tracking);
        }

        [HttpGet]
        [Route("records/tnumber/{tracking_number}")]
        public async Task<IActionResult> GetByTrackingNumber(string tracking_number = "")
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tracking = new object();

            if (tracking_number.IsNullOrEmpty())
                return BadRequest();

            tracking = await _trackingService.GetTrackingRecordByNumberAsync(tracking_number);

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
        [Route("{chat_id}")]
        public async Task<IActionResult> GetTracking(string chat_id = "")
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (chat_id.IsNullOrEmpty())
                return BadRequest();

            var trackings = await _trackingService.GetTrackingRecordListByChatIdAsync(chat_id);

            if (trackings.IsNull())
                return NotFound();

            var trackingNumbers = trackings.Select(t => t.TrackingNumber).ToList();

            var result = await _correiosService.GetTrackings(trackingNumbers);

            return Ok(result);
        }
    }
}
