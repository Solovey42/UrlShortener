using API.Domain.Models;
using API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public async Task<IEnumerable<Link>> GetLinksAsync()
        {
            return await _linkRepository.ListAsync();
        }
        public async Task<Link> GetLinkByIdAsync(int id)
        {
            var link = await _linkRepository.LinkByIdAsync(id);
            return link;
        }
        public async Task<Link> AddLinkAsync(string longAddress)
        {

            Regex regex = new Regex(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$");
            if (!regex.IsMatch(longAddress)) 
            {
                return null;
            }
            Link link;   
            if (!longAddress.StartsWith("https://"))
            {
                link = await _linkRepository.Contains("https://"+longAddress);
                if (link != null)
                {
                    return link;

                }
                link = new Link { LongAddress = "https://"+longAddress, Token = Generate() };
            }
            else
            {
                link = await _linkRepository.Contains(longAddress);
                if (link != null)
                {
                    return link;

                }
                link = new Link { LongAddress = longAddress, Token = Generate() };
            }
            return await _linkRepository.AddLinkAsync(link);
        }
        public async Task<string> GetLongAddressAsync(string token)
        {
            var link = await _linkRepository.LinkByTokenAsync(token);
            if (link == null)
                return null;
            return link.LongAddress;
        }

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
    }
}
