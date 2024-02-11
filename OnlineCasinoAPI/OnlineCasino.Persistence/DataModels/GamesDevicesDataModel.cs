using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.DataModels
{
    public class GamesDevicesDataModel
    {
        public int GamesID { get; set; }
        public int DevicesID { get; set; }
        public virtual GamesDataModel Game { get; set; }
        public virtual DevicesDataModel Device { get; set; }
    }
}
