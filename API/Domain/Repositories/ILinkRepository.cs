using API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Domain.Repositories
{
    public interface ILinkRepository
    {
        Task<IEnumerable<Link>> ListAsync();
    }
}
