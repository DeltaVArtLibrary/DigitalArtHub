﻿using ArtHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public interface IArtRepository
    {
        Task<IEnumerable<Art>> GetAllArt();
        Task<Art> GetArtPiece(int id);
    }
}