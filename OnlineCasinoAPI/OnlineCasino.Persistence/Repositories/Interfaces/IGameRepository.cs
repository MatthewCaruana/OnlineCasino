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
    }
}
