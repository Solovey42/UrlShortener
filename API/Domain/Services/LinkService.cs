using API.Domain.Models;
using API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (link.Result == null)
                return null;
            return link;
        }
        public async Task<Link> AddLinkAsync(string longAddress)
        {
            var link = await _linkRepository.Contains(longAddress);
            if (link!=null)
            {
                return link; 

            }
            if (!longAddress.StartsWith("https://"))
            {
                link = new Link { LongAddress = "https://"+longAddress, Token = Generate() };
            }
            else
            {
                link = new Link { LongAddress = longAddress, Token = Generate() };
            }
            return await _linkRepository.AddLinkAsync(link);

        }
        public string GetLongAddressAsync(string token)
        {
            var link = _linkRepository.LinkByTokenAsync(token);
            if (link.Result == null)
                return null;
            return link.Result.LongAddress;
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
