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

        public HomeController(ILogger<HomeController> logger, /*LinksContext context, */ ILinkService linkService)
        {
            _logger = logger;
            _linkService = linkService;
        }

        [HttpGet("getLinks")]
        public async Task<IEnumerable<Link>> Get()
        {
            ///return await _context.Links.ToListAsync();
            var links = await _linkService.GetLinksAsync();
            return links;
        }

        [HttpGet("getLink/{id}")]
        public async Task<ActionResult<Link>> Get(int id)
        {
            ///Link link = await _context.Links.FirstOrDefaultAsync(x => x.Id == id);
            var link = await _linkService.GetLinkByIdAsync(id);
            if (link == null)
                return NotFound();
            return new ObjectResult(link);
        }
        [HttpGet("{token}")]
        public IActionResult Get(string token)
        {
            var hostUrl = Request.Scheme + "://" + Request.Host.Value;

            return Redirect("http://microsoft.com");
        }

        [HttpPost("addLink/{*longAddress}")]
        public async Task<ActionResult<Link>> Post(string longAddress)
        {
            if (longAddress == null)
            {
                return BadRequest();
            }
            ///_context.Links.Add(link);
            ///await _context.SaveChangesAsync();
            var link = await _linkService.AddLinkAsync(longAddress);
            return Ok(link);
        }

/*        [HttpPut]
        public async Task<ActionResult<Link>> Put(Link link)
        {
            if (link == null)
            {
                return BadRequest();
            }
            if (*//*!_context.Links.Any(x => x.Id == link.Id)*//*_linkService.Contains(link))
            {
                return NotFound();
            }
            ///_context.Update(link);
            ///await _context.SaveChangesAsync();
            _linkService.Put(link);
            return Ok(link);
        }*/

/*        [HttpDelete("{id}")]
        public async Task<ActionResult<Link>> Delete(int id)
        {
            ///Link link = _context.Links.FirstOrDefault(x => x.Id == id);
            var link = _linkService.Get(id); ///////////////////////////////////////////////тут не работает потому что возвращается Task
            if (link == null)
            {
                return NotFound();
            }
            //_context.Links.Remove(link);
            //await _context.SaveChangesAsync();
            _linkService.Delete(link); 
            return Ok(link);
        }*/
    }
}
