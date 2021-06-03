using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Services
{
    public interface IFileService
    {
        Task<string> Create(IFormFile artFile);
        // need an update
        Task<string> Update(IFormFile artFile);
    }
}
