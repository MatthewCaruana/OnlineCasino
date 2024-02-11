﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
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
        public void GetAllGames()
        {

        }
    }
}