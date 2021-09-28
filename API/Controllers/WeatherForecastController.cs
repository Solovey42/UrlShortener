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
    }
}
