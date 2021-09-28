using API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Domain.Services
{
    public interface ILinkService
    {
        Task<IEnumerable<Link>> ListAsync();
    }
}
