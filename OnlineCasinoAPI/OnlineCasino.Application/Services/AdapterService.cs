using OnlineCasino.Application.DTOs;
using OnlineCasino.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.Services
{
    public class AdapterService
    {
        public static List<AllGamesDTO> AdaptToAllGamesDTO(List<GamesDataModel> dataModels)
        {
            List<AllGamesDTO> AllGamesDTOs = new List<AllGamesDTO>();

            return AllGamesDTOs;
        }
    }
}
