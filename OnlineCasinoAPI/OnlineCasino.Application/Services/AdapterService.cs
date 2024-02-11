using OnlineCasino.Application.DTOs;
using OnlineCasino.Persistence.DataModels;
using OnlineCasino.Shared.Enums;
using OnlineCasino.Shared.Services;
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

            AllGamesDTO tempDTO;

            foreach(GamesDataModel gamesDataModel in dataModels)
            {
                tempDTO = new AllGamesDTO();
                tempDTO.ID = gamesDataModel.ID;
                tempDTO.Name = gamesDataModel.Name;
                tempDTO.ReleaseDate = gamesDataModel.ReleaseDate;
                tempDTO.CategoryName = gamesDataModel.Category.Name;
                tempDTO.Thumbnail = gamesDataModel.Thumbnail;

                tempDTO.Devices = gamesDataModel.GameDevices.Select(x => x.Device.Name).ToList();
                tempDTO.Collections = gamesDataModel.GameCollections.Select(x=>x.Collection.Name).ToList();
                AllGamesDTOs.Add(tempDTO);
            }

            return AllGamesDTOs;
        }
    }
}
