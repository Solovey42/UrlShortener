using API.Domain.Models;
using API.Domain.Repositories;
using System;
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
        public Task<Link> AddLinkAsync(string longAddress)
        {
            var link = new Link { LongAddress = longAddress, Token = Generate() };
            return _linkRepository.AddLinkAsync(link);

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
            Random rd = new Random();
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            char[] chars = new char[7];
            for (int i = 0; i < 7; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }



/*        public void Put(Link link)
        {
            _linkRepository.Put(link);
        }*/
    }
}
