using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        LinksContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, LinksContext context)
        {
            _logger = logger;
            db = context;
            if (!db.Links.Any())
            {
                db.Links.Add(new Link { LongAddress = "www.google.com", Token = "fa31" });
                db.Links.Add(new Link { LongAddress = "www.drom.ru", Token = "nhtr3" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> Get()
        {
            return await db.Links.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Link>> Get(int id)
        {
            Link link = await db.Links.FirstOrDefaultAsync(x => x.Id == id);
            if (link == null)
                return NotFound();
            return new ObjectResult(link);
        }

        [HttpPost]
        public async Task<ActionResult<Link>> Post(Link link)
        {
            if (link == null)
            {
                return BadRequest();
            }

            db.Links.Add(link);
            await db.SaveChangesAsync();
            return Ok(link);
        }

        [HttpPut]
        public async Task<ActionResult<Link>> Put(Link link)
        {
            if (link == null)
            {
                return BadRequest();
            }
            if (!db.Links.Any(x => x.Id == link.Id))
            {
                return NotFound();
            }

            db.Update(link);
            await db.SaveChangesAsync();
            return Ok(link);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Link>> Delete(int id)
        {
            Link link = db.Links.FirstOrDefault(x => x.Id == id);
            if (link == null)
            {
                return NotFound();
            }
            db.Links.Remove(link);
            await db.SaveChangesAsync();
            return Ok(link);
        }
    }
}
