using API.Domain.Models;
using API.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ILinkService _linkService;

        public HomeController(ILogger<HomeController> logger, ILinkService linkService)
        {
            _logger = logger;
            _linkService = linkService;
        }

        [HttpGet("getLinks")]
        public async Task<IEnumerable<Link>> Get()
        {
            var links = await _linkService.GetLinksAsync();
            return links;
        }

        [HttpGet("getLink/{id}")]
        public async Task<ActionResult<Link>> Get(int id)
        {
            var link = await _linkService.GetLinkByIdAsync(id);
            if (link == null)
                return NotFound();
            return new ObjectResult(link);
        }
        [HttpGet("{token}")]
        public IActionResult Get(string token)
        {
            string longAddress = _linkService.GetLongAddressAsync(token);
            if (longAddress == null)
            {
                return NotFound();
            }
            return Redirect(_linkService.GetLongAddressAsync(token));
        }

        [HttpPost("addLink")]
        public async Task<ActionResult<Link>> Post(string longAddress)
        {
            if (longAddress == null)
            {
                return BadRequest();
            }
            var link = await _linkService.AddLinkAsync(longAddress);
            return Ok(link);
        }
    }
}
