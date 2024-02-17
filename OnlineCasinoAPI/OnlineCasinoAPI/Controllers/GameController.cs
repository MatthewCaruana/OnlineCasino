using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCasino.Application.DTOs;
using OnlineCasino.Application.Services.Interfaces;

namespace OnlineCasinoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private IGameService _gameService;

        public GameController(ILogger<GameController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpGet]
        [Route("GetAllGames")]
        [AllowAnonymous]
        public List<AllGamesDTO> GetAllGames()
        {
            return _gameService.GetAllGames();
        }

        [HttpGet]
        [Route("GetAllCollections")]
        [AllowAnonymous]
        public List<AllCollectionsDTO> GetAllCollections()
        {
            return _gameService.GetAllCollections();
        }

        [HttpGet]
        [Route("GetGame")]
        [AllowAnonymous]
        public AllGamesDTO GetGame(int id)
        {
            return _gameService.GetGameById(id);
        }

        [HttpGet]
        [Route("GetCollection")]
        [AllowAnonymous]
        public AllCollectionsDTO GetCollection(int id)
        {
            return _gameService.GetCollectionById(id);
        }
    }
}
