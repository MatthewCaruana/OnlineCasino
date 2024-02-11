using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.DataModels
{
    public class GamesCollectionsDataModel
    {
        public int GamesID { get; set; }
        public int CollectionsID { get; set; }

        public virtual GamesDataModel Game { get; set; }
        public virtual CollectionsDataModel Collection { get; set; }
    }
}
