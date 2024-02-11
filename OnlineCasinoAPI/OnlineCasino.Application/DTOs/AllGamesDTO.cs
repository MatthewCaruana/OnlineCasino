using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.DTOs
{
    public class AllGamesDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CategoryName { get; set; }
        public byte[] Thumbnail { get; set; }
        public List<string> Devices { get; set; }
        public List<string> Collections { get; set; }
    }
}
