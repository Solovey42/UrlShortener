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
        public async Task<ActionResult<IEnumerable<Link>>> Get()
        {
            try
            {
                return new ObjectResult(await _linkService.GetLinksAsync());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getLink/{id}")]
        public async Task<ActionResult<Link>> Get(int id)
        {
            try
            {
                var link = await _linkService.GetLinkByIdAsync(id);
                if (link == null)
                    return NotFound();
                return link;
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpGet("{token}")]
        public async Task<IActionResult> Get(string token)
        {
            try
            {
                return Redirect(await _linkService.GetLongAddressAsync(token));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("addLink")]
        public async Task<ActionResult<Link>> Post(Link link)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                return await _linkService.AddLinkAsync(link.LongAddress);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
