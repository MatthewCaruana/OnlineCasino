using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.DataModels
{
    public class CollectionsDataModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<GamesCollectionsDataModel> GamesCollections { get; set; }
        public virtual List<CollectionTreeDataModel> CollectionTreeRoots { get; set; }
        public virtual List<CollectionTreeDataModel> CollectionTreeBranches { get; set; }
    }
}
