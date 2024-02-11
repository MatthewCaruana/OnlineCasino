using OnlineCasino.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.Services.Interfaces
{
    public interface IGameService
    { 
        public List<AllGamesDTO> GetAllGames();
    }
}
