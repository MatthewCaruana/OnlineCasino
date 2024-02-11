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
    public class GamesDevicesMap : IEntityTypeConfiguration<GamesDevicesDataModel>
    {
        public void Configure(EntityTypeBuilder<GamesDevicesDataModel> builder)
        {
            builder.Property(x => x.DevicesID).HasColumnName("DevicesID");
            builder.Property(x => x.GamesID).HasColumnName("GamesID");
        }
    }
}
