using OnlineCasino.Application.DTOs;
using OnlineCasino.Application.Services.Interfaces;
using OnlineCasino.Persistence.Context.Interfaces;
using OnlineCasino.Persistence.Repositories.Interfaces;
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
            throw new NotImplementedException();
        }

        public void CreateGame(CreateGameDTO newGame)
        {
            throw new NotImplementedException();
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
