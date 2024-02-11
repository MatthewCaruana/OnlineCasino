using OnlineCasino.Application.DTOs;
using OnlineCasino.Application.Services.Interfaces;
using OnlineCasino.Persistence.DataModels;
using OnlineCasino.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.Services
{
    public class GameService : IGameService
    {
        private IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public List<AllGamesDTO> GetAllGames()
        {
            List<GamesDataModel> AllGames = _gameRepository.GetAllGames();

            List<AllGamesDTO> Result = AdapterService.AdaptToAllGamesDTO(AllGames);

            return Result;
        }

        public List<AllCollectionsDTO> GetAllCollections()
        {
            List<CollectionsDataModel> AllCollections = _gameRepository.GetAllCollections();

            //List<AllCollectionsDTO> Result = AdapterService.AdaptToAllCollectionsDTO(AllCollections);

            return null;
        }
    }
}
