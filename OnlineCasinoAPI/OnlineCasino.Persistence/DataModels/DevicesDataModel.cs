using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.DataModels
{
    public class DevicesDataModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<GamesDevicesDataModel> GameDevices { get; set; }
    }
}
