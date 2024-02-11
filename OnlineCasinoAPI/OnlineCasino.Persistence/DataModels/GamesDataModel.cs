using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.DataModels
{
    public class GamesDataModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Thumbnail { get; set; }
        public int CategoryID { get; set; }

        public virtual CategoriesDataModel Category { get; set; }
        public virtual List<GamesCollectionsDataModel> GameCollections { get; set; }
        public virtual List<GamesDevicesDataModel> GameDevices { get; set; }
    }
}
