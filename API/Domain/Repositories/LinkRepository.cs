using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain.Repositories
{
    public class LinkRepository : BaseRepository, ILinkRepository
    {
        public LinkRepository(LinksContext context) : base(context)
        {

        }

        public async Task<Link> Contains(string longAddress)
        {
            return await _context.Links.FirstOrDefaultAsync(x => x.LongAddress == longAddress);
        }

        public async Task<IEnumerable<Link>> ListAsync()
        {
            return await _context.Links.ToListAsync();
        }
        public async Task<Link> LinkByIdAsync(int id)
        {
            var link = await _context.Links.FirstOrDefaultAsync(x => x.Id == id);
            if (link == null)
                return null;
            else
                return link;
        }

        public async Task<Link> AddLinkAsync(Link link)
        {
            _context.Links.Add(link);
            await _context.SaveChangesAsync();
            return link;
        }

        public async Task<Link> LinkByTokenAsync(string token)
        {
            return await _context.Links.FirstOrDefaultAsync(x => x.Token == token);
        }
    }
}
