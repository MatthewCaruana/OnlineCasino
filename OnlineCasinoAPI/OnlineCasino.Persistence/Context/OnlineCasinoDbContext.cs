using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineCasino.Persistence.Context.Interfaces;
using OnlineCasino.Persistence.DataMappings;
using OnlineCasino.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.Context
{
    public class OnlineCasinoDbContext : DbContext, IOnlineCasinoDbContext
    {
        protected readonly IConfiguration Configuration;

        public DbSet<GamesDataModel> Games { get; set; }
        public DbSet<GamesCollectionsDataModel> GamesCollections { get; set; }
        public DbSet<GamesDevicesDataModel> GamesDevices { get; set; }
        public DbSet<CategoriesDataModel> Categories { get; set; }
        public DbSet<CollectionsDataModel> Collections { get; set; }
        public DbSet<DevicesDataModel> Devices { get; set; }
        public DbSet<CollectionTreeDataModel> CollectionTrees { get; set; }
        public DbSet<UsersDataModel> Users { get; set; }

        public OnlineCasinoDbContext() { }

        public OnlineCasinoDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GamesMap());
            modelBuilder.ApplyConfiguration(new GamesCollectionsMap());
            modelBuilder.ApplyConfiguration(new GamesDevicesMap());
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new CollectionsMap());
            modelBuilder.ApplyConfiguration(new DevicesMap());
            modelBuilder.ApplyConfiguration(new CollectionTreeMap());
            modelBuilder.ApplyConfiguration(new UsersMap());
        }

        public new void SaveChanges()
        {
            var a = this.ChangeTracker.Entries().ToArray();
            base.SaveChanges();
        }
    }
}
