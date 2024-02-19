using Microsoft.EntityFrameworkCore;
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

        public void AddGame(GamesDataModel game)
        {
            _context.Games.Add(game);
        }

        public void AddGameDevice(List<GamesDevicesDataModel> gamesDevices)
        {
            _context.GamesDevices.AddRange(gamesDevices);
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

        public GamesDataModel? GetGameById(int id)
        {
            return _context.Games.Include("GameCollections")
                                 .Include("GameCollections.Collection")
                                 .Include("GameDevices")
                                 .Include("GameDevices.Device")
                                 .Include("Category")
                                 .FirstOrDefault(x=>x.ID == id);
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

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
