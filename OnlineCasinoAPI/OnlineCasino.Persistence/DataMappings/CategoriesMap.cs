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
    public class CategoriesMap : IEntityTypeConfiguration<CategoriesDataModel>
    {
        public void Configure(EntityTypeBuilder<CategoriesDataModel> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasColumnName("ID");
            builder.Property(x=>x.Name).HasColumnName("Name");
        }
    }
}
