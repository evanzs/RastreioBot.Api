﻿using System.Diagnostics;
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
        [Route("")]
        [Route("{tracking_number}")]
        public async Task<IActionResult> Get(string tracking_number = "")
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tracking = new object();

            if (string.IsNullOrWhiteSpace(tracking_number))
                tracking = await Task.Factory.StartNew(() => _service.GetTrackingListAsync()).Result;
            else
                tracking = await Task.Factory.StartNew(() => _service.GetTrackingAsync(tracking_number)).Result;

            if (tracking is null)
                return NotFound();

            return Ok(tracking);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TrackingApi trackingApi)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tracking = await Task.Factory.StartNew(() => _service.InsertNewTrackingAsync(trackingApi)).Result;

            var statusCode = (int)HttpStatusCode.Created;

            if (tracking is not Tracking)
                statusCode = (int)HttpStatusCode.InternalServerError;

            return StatusCode(statusCode, tracking);
        }
    }
}