using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Models.Api.Users;

namespace RastreioBot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // [HttpGet]
        // [Route(("{id}"))]
        // public ActionResult Get(int id)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest();

        //     var user = _userService.GetUserAsync(id);

        //     if (user is null)
        //         return NotFound();

        //     return Ok(user);
        // }

        [HttpGet]
        [Route("{token}")]
        public async Task<ActionResult> Get(string token)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userService.GetUserAsync(token);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserApi userApi)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userService.AddUserAsync(userApi);

            if (user is null)
                return StatusCode((int)HttpStatusCode.InternalServerError);

            return Created($"~api/users/get/{user.Token}", user);
        }
    }
}
