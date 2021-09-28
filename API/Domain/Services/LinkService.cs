using API.Domain.Models;
using API.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Domain.Services
{
    public class LinkService : ILinkService
    {
        ILinkRepository _linkRepository;
        
        public LinkService(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }
        public Task<IEnumerable<Link>> ListAsync()
        {
            return _linkRepository.ListAsync();
        }
    }
}
