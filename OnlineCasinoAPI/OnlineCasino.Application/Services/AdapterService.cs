using OnlineCasino.Application.DTOs;
using OnlineCasino.Persistence.DataModels;
using OnlineCasino.Shared.Enums;
using OnlineCasino.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public static List<AllCollectionsDTO> AdaptToAllCollectionsDTO(List<CollectionsDataModel> dataModels)
        {
            List<AllCollectionsDTO> AllCollectionsDTOs = new List<AllCollectionsDTO>();

            AllCollectionsDTO tempDTO;

            foreach(CollectionsDataModel dataModel in dataModels)
            {
                tempDTO = new AllCollectionsDTO();

                tempDTO.ID = dataModel.ID;
                tempDTO.Name = dataModel.Name;
                tempDTO.GameIDs = dataModel.GamesCollections.Select(x=>x.GamesID).ToList();
                
                if(dataModel.CollectionTreeRoots.Count > 0)
                {
                    tempDTO.SubCollections = AdapterService.AdaptToAllCollectionsDTO(dataModel.CollectionTreeBranch.Select(x=>x.Branch).ToList());
                }

                AllCollectionsDTOs.Add(tempDTO);
            }

            return AllCollectionsDTOs;
        }
    }
}
