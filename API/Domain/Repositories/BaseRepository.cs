using API.Domain.Models;

namespace API.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly LinksContext _context;

        public BaseRepository(LinksContext context)
        {
            _context = context;
        }
    }
}
