﻿using ArtHub.Models;
using ArtHub.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public interface IArtRepository
    {
        Task<List<AllArtDto>> GetAllArt();
        Task<ArtDto> GetArt(int id);
        Task CreateArt(CreateArtData art);
        Task<bool> UpdateArt(int id, CreateArtData art);
        Task<bool> DeleteArt(int id);
    }
}
