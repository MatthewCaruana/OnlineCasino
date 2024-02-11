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

        public List<CollectionsDataModel> GetAllCollections()
        {
            return _context.Collections.ToList();
        }

        public List<GamesDataModel> GetAllGames()
        {
            return _context.Games.ToList();
        }
    }
}
