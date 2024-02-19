using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCasino.Application.DTOs;
using OnlineCasino.Application.Services.Interfaces;

namespace OnlineCasinoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GameMasterController : ControllerBase
    {
        private readonly ILogger<GameMasterController> _logger;
        private IGameManagerService _gameManagerService;

        public GameMasterController(ILogger<GameMasterController> logger, IGameManagerService gameManagerService)
        {
            _logger = logger;
            _gameManagerService = gameManagerService;
        }

        [HttpPost]
        [Route("CreateGame")]
        public void CreateGame([FromBody] CreateGameDTO createGame)
        {
            _gameManagerService.CreateGame(createGame);
        }

        [HttpPost]
        [Route("CreateCollection")]
        public void CreateCollection([FromBody] CreateCollectionDTO createCollection)
        {
            _gameManagerService.CreateCollection(createCollection);
        }

        [HttpPut]
        [Route("UpdateGame")]
        public void UpdateGame([FromBody] UpdateGameDTO updateGame)
        {
            _gameManagerService.UpdateGame(updateGame);
        }

        [HttpPut]
        [Route("UpdateCollection")]
        public void UpdateCollection([FromBody] UpdateCollectionDTO updateCollection)
        {
            _gameManagerService.UpdateCollection(updateCollection);
        }

        [HttpDelete]
        [Route("DeleteGame")]
        public void DeleteGame([FromBody] int id)
        {
            _gameManagerService.DeleteGame(id);
        }

        [HttpPut]
        [Route("DeleteCollection")]
        public void DeleteCollection([FromBody] int id)
        {
            _gameManagerService.DeleteCollection(id);
        }
    }
}
