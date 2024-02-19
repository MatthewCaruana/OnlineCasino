using OnlineCasino.Application.DTOs;
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
            CollectionsDataModel collectionsDataModel = new CollectionsDataModel();
            collectionsDataModel.Name = newCollection.Name;
            
            _repo.AddCollection(collectionsDataModel);
            _repo.SaveChanges();

            List<CollectionTreeDataModel> collectionTreeDataModels = new List<CollectionTreeDataModel>();
            if(newCollection.CollectionIds != null && newCollection.CollectionIds.Count > 0)
            {
                foreach(int collectionBranchId in newCollection.CollectionIds)
                {
                    collectionTreeDataModels.Add(new CollectionTreeDataModel()
                    {
                        CollectionRootID = collectionsDataModel.ID,
                        CollectionBranchID = collectionBranchId
                    });
                }
            }

            List<GamesCollectionsDataModel> gameCollectionsDataModels = new List<GamesCollectionsDataModel>();
            if(newCollection.GameIds != null && newCollection.GameIds.Count > 0)
            {
                foreach(int gameId in newCollection.GameIds)
                {
                    gameCollectionsDataModels.Add(new GamesCollectionsDataModel()
                    {
                        CollectionsID = collectionsDataModel.ID,
                        GamesID = gameId
                    });
                }
            }

            if(gameCollectionsDataModels.Count > 0)
            {
                _repo.AddGamesCollections(gameCollectionsDataModels);
            }
            if(collectionTreeDataModels.Count > 0)
            {
                _repo.AddCollectionTree(collectionTreeDataModels);
            }
            _repo.SaveChanges();
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

            if(gamesCollectionsDataModels.Count > 0)
            {
                _repo.AddGamesCollections(gamesCollectionsDataModels);

            }
            if(gamesDevicesDataModels.Count > 0)
            {
                _repo.AddGameDevice(gamesDevicesDataModels);
            }
            _repo.SaveChanges();
        }

        public void DeleteCollection(int id)
        {
            _repo.RemoveCollection(id);
            _repo.SaveChanges();
        }

        public void DeleteGame(int id)
        {
            _repo.RemoveGame(id);
            _repo.SaveChanges();
        }

        public void UpdateCollection(UpdateCollectionDTO updatedCollection)
        {
            CollectionsDataModel collection = _repo.GetCollectionById(updatedCollection.Id);

            if(collection != null)
            {
                collection.Name = updatedCollection.Name;

                //Add new collection tree entries
                List<CollectionTreeDataModel> collectionTrees = _repo.GetCollectionTreesWithRootId(updatedCollection.Id);
                foreach(int collectionBranch in updatedCollection.CollectionIds)
                {
                    if(!collectionTrees.Any(x=>x.CollectionBranchID == collectionBranch))
                    {
                        CollectionTreeDataModel collectionTree = new CollectionTreeDataModel();
                        collectionTree.CollectionRootID = collection.ID;
                        collectionTree.CollectionBranchID = collectionBranch;

                        _repo.AddCollectionTree(collectionTree);
                    }
                }

                //Get list of removed collection trees and remove them
                List<CollectionTreeDataModel> collectionTreesToRemove = collectionTrees.Where(x => !updatedCollection.CollectionIds.Any(y => y == x.CollectionRootID)).ToList();
                _repo.RemoveCollectionTrees(collectionTreesToRemove);


                //Add new games added to list
                List<GamesCollectionsDataModel> gameCollections = _repo.GetGameCollectionsForCollection(updatedCollection.Id);
                foreach (int gameId in updatedCollection.GameIds)
                {
                    if (!gameCollections.Any(x => x.GamesID == gameId))
                    {
                        GamesCollectionsDataModel gameCollection = new GamesCollectionsDataModel();
                        gameCollection.CollectionsID = collection.ID;
                        gameCollection.GamesID = gameId;

                        _repo.AddGameCollection(gameCollection);
                    }
                }

                //Get list of removed games and remove them
                List<GamesCollectionsDataModel> gameCollectionsToRemove = gameCollections.Where(x => !updatedCollection.GameIds.Any(y => y == x.GamesID)).ToList();
                _repo.RemoveGameCollections(gameCollectionsToRemove);

                _repo.UpdateCollection(collection);
                
                _repo.SaveChanges();
            }
            else
            {
            }

        }

        public void UpdateGame(UpdateGameDTO updatedGame)
        {
            GamesDataModel game = _repo.GetGameById(updatedGame.Id);

            if(game != null)
            {

            }
            else
            {

            }

            _repo.SaveChanges();
        }
    }
}
