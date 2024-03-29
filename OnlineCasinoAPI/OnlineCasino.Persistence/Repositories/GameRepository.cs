﻿using Microsoft.EntityFrameworkCore;
using OnlineCasino.Persistence.Context.Interfaces;
using OnlineCasino.Persistence.DataModels;
using OnlineCasino.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.Repositories
{
    public class GameRepository : IGameRepository
    {
        private IOnlineCasinoDbContext _context;

        public GameRepository(IOnlineCasinoDbContext context)
        {
            _context = context;
        }

        public void AddCollection(CollectionsDataModel collection)
        {
            _context.Collections.Add(collection);
        }

        public void AddCollectionTree(List<CollectionTreeDataModel> collectionTrees)
        {
            _context.CollectionTree.AddRange(collectionTrees);
        }

        public void AddCollectionTree(CollectionTreeDataModel collectionTree)
        {
            _context.CollectionTree.Add(collectionTree);
        }

        public void AddGame(GamesDataModel game)
        {
            _context.Games.Add(game);
        }

        public void AddGameCollection(GamesCollectionsDataModel gamesCollection)
        {
            _context.GamesCollections.Add(gamesCollection);
        }

        public void AddGameDevice(List<GamesDevicesDataModel> gamesDevices)
        {
            _context.GamesDevices.AddRange(gamesDevices);
        }

        public void AddGameDevice(GamesDevicesDataModel gamesDevice)
        {
            _context.GamesDevices.Add(gamesDevice);
        }

        public void AddGamesCollections(List<GamesCollectionsDataModel> gamesCollections)
        {
            _context.GamesCollections.AddRange(gamesCollections);
        }

        public List<CollectionsDataModel> GetAllCollections()
        {
            return _context.Collections.Include("GamesCollections")
                                       .Include("GamesCollections.Game")
                                       .Include("CollectionTreeRoots")
                                       .Include("CollectionTreeBranches")
                                       .ToList();
        }

        public List<GamesDataModel> GetAllGames()
        {
            return _context.Games.Include("GameCollections")
                                 .Include("GameCollections.Collection")
                                 .Include("GameDevices")
                                 .Include("GameDevices.Device")
                                 .Include("Category")
                                 .ToList();
        }

        public CollectionsDataModel? GetCollectionById(int id)
        {
            return _context.Collections.Include("GamesCollections")
                                       .Include("GamesCollections.Game")
                                       .Include("CollectionTreeRoots")
                                       .Include("CollectionTreeBranches")
                                       .FirstOrDefault(x=>x.ID == id);
        }

        public List<CollectionTreeDataModel> GetCollectionTreesWithRootId(int id)
        {
            return _context.CollectionTree.Where(x=>x.CollectionRootID == id).ToList();
        }

        public GamesDataModel? GetGameById(int id)
        {
            return _context.Games.Include("GameCollections")
                                 .Include("GameCollections.Collection")
                                 .Include("GameDevices")
                                 .Include("GameDevices.Device")
                                 .Include("Category")
                                 .FirstOrDefault(x=>x.ID == id);
        }

        public List<GamesCollectionsDataModel> GetGameCollectionsForCollection(int id)
        {
            return _context.GamesCollections.Where(x => x.CollectionsID == id).ToList();
        }

        public List<GamesCollectionsDataModel> GetGameCollectionsForGame(int id)
        {
            return _context.GamesCollections.Where(x=>x.GamesID == id).ToList();
        }

        public List<GamesDevicesDataModel> GetGameDevicesForGame(int id)
        {
            return _context.GamesDevices.Where(x=>x.GamesID == id).ToList();
        }

        public void RemoveCollection(int id)
        {
            var Collection = GetCollectionById(id);

            if (Collection != null)
            {
                _context.CollectionTree.RemoveRange(Collection.CollectionTreeRoots);
                _context.CollectionTree.RemoveRange(Collection.CollectionTreeBranches);

                _context.GamesCollections.RemoveRange(Collection.GamesCollections);

                _context.Collections.Remove(Collection);
            }
        }

        public void RemoveCollectionTrees(List<CollectionTreeDataModel> collectionTrees)
        {
            _context.CollectionTree.RemoveRange(collectionTrees);
        }

        public void RemoveGame(int id)
        {
            var Game = GetGameById(id);

            if (Game != null)
            {
                _context.GamesDevices.RemoveRange(Game.GameDevices);
                _context.GamesCollections.RemoveRange(Game.GameCollections);

                _context.Games.Remove(Game);
            }
        }

        public void RemoveGameCollections(List<GamesCollectionsDataModel> gameCollections)
        {
            _context.GamesCollections.RemoveRange(gameCollections);
        }

        public void RemoveGameDevices(List<GamesDevicesDataModel> gameDevices)
        {
            _context.GamesDevices.RemoveRange(gameDevices);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateCollection(CollectionsDataModel collection)
        {
            _context.Collections.Update(collection);
        }

        public void UpdateGame(GamesDataModel game)
        {
            _context.Games.Update(game);
        }
    }
}
