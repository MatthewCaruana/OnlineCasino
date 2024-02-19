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

        public List<CollectionTreeDataModel> GetCollectionTreesWithRootId(int id);
        public List<GamesCollectionsDataModel> GetGameCollectionsForCollection(int id);

        public void AddGame(GamesDataModel game);
        public void AddGameDevice(List<GamesDevicesDataModel> gamesDevices);
        public void AddGamesCollections(List<GamesCollectionsDataModel> gamesCollections);
        public void AddGameCollection(GamesCollectionsDataModel gamesCollection);

        public void AddCollection(CollectionsDataModel collection);
        public void AddCollectionTree(List<CollectionTreeDataModel> collectionTrees);
        public void AddCollectionTree(CollectionTreeDataModel collectionTree);

        public void UpdateGame(GamesDataModel game);
        public void UpdateCollection(CollectionsDataModel collection);

        public void RemoveGame(int id);
        public void RemoveCollection(int id);
        public void RemoveCollectionTrees(List<CollectionTreeDataModel> collectionTrees);
        public void RemoveGameCollections(List<GamesCollectionsDataModel> gameCollections);

        public void SaveChanges();
    }
}
