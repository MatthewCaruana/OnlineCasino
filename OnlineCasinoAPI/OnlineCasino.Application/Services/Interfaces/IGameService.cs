﻿using OnlineCasino.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.Services.Interfaces
{
    public interface IGameService
    { 
        public List<AllGamesDTO> GetAllGames();
        public List<AllCollectionsDTO> GetAllCollections();
        public AllGamesDTO GetGameById(int id);
        public AllCollectionsDTO GetCollectionById(int id);
    }
}
