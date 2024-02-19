using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCasino.Application.DTOs;
using OnlineCasino.Application.Services.Interfaces;
using OnlineCasino.Shared.Exceptions;

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
        public IActionResult UpdateGame([FromBody] UpdateGameDTO updateGame)
        {
            try
            {
                _gameManagerService.UpdateGame(updateGame);

                return Ok();

            }catch(GameNotFoundException e)
            {
                return NoContent();
            }
        }

        [HttpPut]
        [Route("UpdateCollection")]
        public IActionResult UpdateCollection([FromBody] UpdateCollectionDTO updateCollection)
        {
            try
            {
                _gameManagerService.UpdateCollection(updateCollection);

                return Ok();
            }catch(CollectionNotFoundException e)
            {
                return NoContent();
            }
        }

        [HttpDelete]
        [Route("DeleteGame")]
        public void DeleteGame([FromBody] int id)
        {
            _gameManagerService.DeleteGame(id);
        }

        [HttpDelete]
        [Route("DeleteCollection")]
        public void DeleteCollection([FromBody] int id)
        {
            _gameManagerService.DeleteCollection(id);
        }
    }
}
