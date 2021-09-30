using API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Domain.Services
{
    public interface ILinkService
    {
        Task<IEnumerable<Link>> GetLinksAsync();
        Task<Link> GetLinkByIdAsync(int id);
        Task<Link> AddLinkAsync(string longAddress);
        string GetLongAddressAsync(string token);
    }
}
