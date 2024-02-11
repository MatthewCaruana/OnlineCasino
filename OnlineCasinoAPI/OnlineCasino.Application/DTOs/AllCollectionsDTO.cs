using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.DTOs
{
    public class AllCollectionsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<int> GameIDs { get; set; }
        public List<AllCollectionsDTO> SubCollections { get; set; }
    }
}
