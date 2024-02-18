using OnlineCasino.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.Repositories.Interfaces
{
    public interface IGameRepository
    {
        public List<GamesDataModel> GetAllGames();
        public List<CollectionsDataModel> GetAllCollections();
        public GamesDataModel? GetGameById(int id);
        public CollectionsDataModel? GetCollectionById(int id);

        public void AddGame(GamesDataModel game);
        public void AddGameDevice(GamesDevicesDataModel gamesDevices);
        public void AddGamesCollections(GamesCollectionsDataModel gamesCollections);

        public void RemoveGame(int id);
        public void RemoveCollection(int id);  

        public void SaveChanges();
    }
}
