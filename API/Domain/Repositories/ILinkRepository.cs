﻿using API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Domain.Repositories
{
    public interface ILinkRepository
    {
        Task<IEnumerable<Link>> ListAsync();
        Task<Link> LinkByIdAsync(int id);
        Task<Link> AddLinkAsync(Link link);
        Task<Link> LinkByTokenAsync(string token);
        ///void Put(Link link);
        ///void Delete(Task<Link> link);
        bool Contains(Link link);
    }
}
