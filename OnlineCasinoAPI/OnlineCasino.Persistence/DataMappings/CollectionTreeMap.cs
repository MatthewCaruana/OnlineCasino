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
    public class CollectionTreeMap : IEntityTypeConfiguration<CollectionTreeDataModel>
    {
        public void Configure(EntityTypeBuilder<CollectionTreeDataModel> builder)
        {
            builder.HasKey(x=>new { x.CollectionBranchID, x.CollectionRootID});

            builder.Property(x => x.CollectionRootID).HasColumnName("CollectionRootID");
            builder.Property(x => x.CollectionBranchID).HasColumnName("CollectionBranchID");

            builder.HasOne(x => x.Root).WithMany(x => x.CollectionTreeRoots).HasForeignKey(x => x.CollectionRootID);
            builder.HasOne(x => x.Branch).WithMany(x => x.CollectionTreeBranch).HasForeignKey(x=>x.CollectionBranchID);
        }
    }
}
