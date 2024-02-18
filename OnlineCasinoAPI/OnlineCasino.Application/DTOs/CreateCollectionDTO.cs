using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.DTOs
{
    public class CreateCollectionDTO
    { 
        public string Name { get; set; }
        public List<int> GameIds { get; set; }
        public List<int> CollectionIds { get; set; }
    }
}
