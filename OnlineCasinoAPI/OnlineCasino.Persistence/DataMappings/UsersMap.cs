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
    public class UsersMap : IEntityTypeConfiguration<UsersDataModel>
    {
        public void Configure(EntityTypeBuilder<UsersDataModel> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasColumnName("ID");
            builder.Property(x => x.Username).HasColumnName("Username");
            builder.Property(x => x.Password).HasColumnName("Password");
            builder.Property(x => x.IsManager).HasColumnName("IsManager");
        }
    }
}
