﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCasino.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.DataMappings
{
    public class GamesMap : IEntityTypeConfiguration<GamesDataModel>
    {
        public void Configure(EntityTypeBuilder<GamesDataModel> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x=>x.ID).HasColumnName("ID");
            builder.Property(x=>x.Name).HasColumnName("Name");
            builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
            builder.Property(x=>x.CategoryID).HasColumnName("CategoryID");
            builder.Property(x => x.Thumbnail).HasColumnName("Thumbnail");
        }
    }
}
