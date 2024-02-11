using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCasino.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.DataMappings
{
    public class GamesCollectionsMap : IEntityTypeConfiguration<GamesCollectionsDataModel>
    {
        public void Configure(EntityTypeBuilder<GamesCollectionsDataModel> builder)
        {
            builder.HasKey(x=> new { x.CollectionsID, x.GamesID});

            builder.Property(x => x.GamesID).HasColumnName("GamesID");
            builder.Property(x => x.CollectionsID).HasColumnName("CollectionsID");

            builder.HasOne(x=>x.Game).WithMany(x=>x.GameCollections).HasForeignKey(x=>x.GamesID);
            builder.HasOne(x=>x.Collection).WithMany(x=>x.GamesCollections).HasForeignKey(x=>x.GamesID);
        }
    }
}
