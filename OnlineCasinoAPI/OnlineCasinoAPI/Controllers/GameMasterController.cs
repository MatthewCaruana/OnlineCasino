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
        private IGameManagerService _gameService;

        public GameMasterController(ILogger<GameMasterController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpPost]
        [Route("CreateGame")]
        public void CreateGame([FromBody] CreateGameDTO createGame)
        {

        }

        [HttpPost]
        [Route("CreateCollection")]
        public void CreateCollection([FromBody] CreateCollectionDTO createCollection)
        {

        }

        [HttpPut]
        [Route("UpdateGame")]
        public void UpdateGame([FromBody] UpdateGameDTO updateGame)
        {

        }

        [HttpPut]
        [Route("UpdateCollection")]
        public void UpdateCollection([FromBody] UpdateCollectionDTO updateCollection)
        {

        }

        [HttpDelete]
        [Route("DeleteGame")]
        public void DeleteGame([FromBody] int id)
        {
            try
            {
                _gameService.DeleteGame(id);
            }
            catch
            {

            }
        }

        [HttpPut]
        [Route("DeleteCollection")]
        public void DeleteCollection([FromBody] int id)
        {

        }
    }
}
