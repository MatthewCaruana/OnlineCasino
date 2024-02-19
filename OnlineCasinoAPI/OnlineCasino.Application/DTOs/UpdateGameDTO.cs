using OnlineCasino.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.DTOs
{
    public class UpdateGameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Categories Category { get; set; }
        public byte[] Thumbnail { get; set; }
        public List<Devices> Devices { get; set; }
        public List<int> Collections { get; set; }
    }
}
