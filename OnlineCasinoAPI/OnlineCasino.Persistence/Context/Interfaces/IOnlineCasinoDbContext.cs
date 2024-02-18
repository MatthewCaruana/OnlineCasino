using Microsoft.EntityFrameworkCore;
using OnlineCasino.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.Context.Interfaces
{
    public interface IOnlineCasinoDbContext
    {
        DbSet<GamesDataModel> Games { get; set; }
        DbSet<GamesCollectionsDataModel> GamesCollections { get; set; }
        DbSet<GamesDevicesDataModel> GamesDevices { get; set; }
        DbSet<CategoriesDataModel> Categories { get; set; }
        DbSet<CollectionsDataModel> Collections { get; set; }
        DbSet<DevicesDataModel> Devices { get; set; }
        DbSet<CollectionTreeDataModel> CollectionTrees { get; set; }
        DbSet<UsersDataModel> Users { get; set; }

        public void SaveChanges();
    }
}
