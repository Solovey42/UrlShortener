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

        public bool Contains(Link link)
        {
            if (_context.Links.Any(x => x.Id == link.Id))
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<Link>> ListAsync()
        {
            return await _context.Links.ToListAsync();
        }
        public async Task<Link> LinkByIdAsync(int id)
        {
            return await _context.Links.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async void AddLinkAsync(Link link)
        {
            _context.Links.Add(link);
            await _context.SaveChangesAsync();
        }


        /*        public async void Delete(Task<Link> link)
                {
                    _context.Links.Remove(link);
                    await _context.SaveChangesAsync();
                }*/

        /*        public async void Put(Link link)
                {
                    _context.Update(link);
                    await _context.SaveChangesAsync();
                }*/
    }
}
