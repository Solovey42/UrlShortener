﻿using API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Domain.Services
{
    public interface ILinkService
    {
        Task<IEnumerable<Link>> GetLinksAsync();
        Task<Link> GetLinkByIdAsync(int id);
        void AddLinkAsync(Link link);
        ///void Put(Link link);
        ///void Delete(Task<Link> link);
        bool Contains( Link link);
        string Generate();
    }
}
