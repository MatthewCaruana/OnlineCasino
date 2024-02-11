using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.DataModels
{
    public class CollectionTreeDataModel
    {
        public int CollectionRootID { get; set; }
        public int CollectionBranchID { get; set; }
        public virtual CollectionsDataModel Root { get; set; }
        public virtual CollectionsDataModel Branch { get; set; }
    }
}
