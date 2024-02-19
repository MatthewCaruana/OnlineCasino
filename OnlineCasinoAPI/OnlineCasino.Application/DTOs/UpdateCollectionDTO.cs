using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.DTOs
{
    public class UpdateCollectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> GameIds { get; set; }
        public List<int> CollectionIds { get; set; }
    }
}
