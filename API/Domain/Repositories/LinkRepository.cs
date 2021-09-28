using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Domain.Repositories
{
    public class LinkRepository : BaseRepository, ILinkRepository
    {
        public LinkRepository(LinksContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Link>> ListAsync()
        {
            return await _context.Links.ToListAsync(); 
        }
    }
}
