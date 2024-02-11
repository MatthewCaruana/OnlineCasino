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
            builder.Property(x => x.GamesID).HasColumnName("GamesID");
            builder.Property(x => x.CollectionsID).HasColumnName("CollectionsID");
        }
    }
}
