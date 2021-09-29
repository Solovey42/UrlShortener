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
        public Task<IEnumerable<Link>> GetLinksAsync()
        {
            return _linkRepository.ListAsync();
        }
        public Task<Link> GetLinkByIdAsync(int id)
        {
            var link = _linkRepository.LinkByIdAsync(id);
            if (link == null)
                return null;
            return link;
        }
        public void AddLinkAsync(Link link)
        {
            _linkRepository.AddLinkAsync(link);

        }
        public bool Contains(Link link)
        {
            return _linkRepository.Contains(link);
        }

/*        public void Delete(Task<Link> link)
        {
            _linkRepository.Delete(link);  

        }*/

        public string Generate()
        {
            throw new System.NotImplementedException();
        }



/*        public void Put(Link link)
        {
            _linkRepository.Put(link);
        }*/
    }
}
