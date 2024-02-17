using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCasino.Application.Services.Interfaces;

namespace OnlineCasinoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GameMasterController : ControllerBase
    {
        private readonly ILogger<GameMasterController> _logger;
        private IGameService _gameService;

        public GameMasterController(ILogger<GameMasterController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }
    }
}
