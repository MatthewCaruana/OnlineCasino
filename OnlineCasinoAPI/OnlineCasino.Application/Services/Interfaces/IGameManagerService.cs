using OnlineCasino.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.Services.Interfaces
{
    public interface IGameManagerService
    {
        public void CreateGame(CreateGameDTO newGame);
        public void UpdateGame(UpdateGameDTO updatedGame);
        public void DeleteGame(int id);

        public void CreateCollection(CreateCollectionDTO newCollection);
        public void UpdateCollection(UpdateCollectionDTO updatedCollection);
        public void DeleteCollection(int id);
    }
}
