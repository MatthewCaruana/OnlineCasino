﻿using OnlineCasino.Application.DTOs;
using OnlineCasino.Application.Services.Interfaces;
using OnlineCasino.Persistence.Context.Interfaces;
using OnlineCasino.Persistence.DataModels;
using OnlineCasino.Persistence.Repositories.Interfaces;
using OnlineCasino.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.Services
{
    public class GameManagerService : IGameManagerService
    {
        private IGameRepository _repo;

        public GameManagerService(IGameRepository repo)
        {
            _repo = repo;
        }

        public void CreateCollection(CreateCollectionDTO newCollection)
        {
            
        }

        public void CreateGame(CreateGameDTO newGame)
        {
            GamesDataModel gamesDataModel = new GamesDataModel();
            gamesDataModel.Name = newGame.Name;
            gamesDataModel.CategoryID = (int)newGame.Category;
            gamesDataModel.ReleaseDate = newGame.ReleaseDate;
            gamesDataModel.Thumbnail = newGame.Thumbnail;

            _repo.AddGame(gamesDataModel);
            _repo.SaveChanges();

            List<GamesCollectionsDataModel> gamesCollectionsDataModels = new List<GamesCollectionsDataModel>();
            if(newGame.Collections != null && newGame.Collections.Count > 0) 
            {
                foreach(int CollectionID in newGame.Collections)
                {
                    gamesCollectionsDataModels.Add(new GamesCollectionsDataModel()
                    {
                        CollectionsID = CollectionID,
                        GamesID = gamesDataModel.ID
                    });
                }
            }

            List<GamesDevicesDataModel> gamesDevicesDataModels = new List<GamesDevicesDataModel>();
            if(newGame.Devices != null && newGame.Devices.Count > 0)
            {
                foreach(Devices devices in newGame.Devices)
                {
                    gamesDevicesDataModels.Add(new GamesDevicesDataModel()
                    {
                        DevicesID = (int)devices,
                        GamesID = gamesDataModel.ID
                    });
                }
            }

            _repo.AddGamesCollections(gamesCollectionsDataModels);
            _repo.AddGameDevice(gamesDevicesDataModels);
        }

        public void DeleteCollection(int id)
        {
            _repo.RemoveCollection(id);
        }

        public void DeleteGame(int id)
        {
            _repo.RemoveGame(id);
        }

        public void UpdateCollection(UpdateCollectionDTO updatedCollection)
        {
            throw new NotImplementedException();
        }

        public void UpdateGame(UpdateGameDTO updatedGame)
        {
            throw new NotImplementedException();
        }
    }
}
