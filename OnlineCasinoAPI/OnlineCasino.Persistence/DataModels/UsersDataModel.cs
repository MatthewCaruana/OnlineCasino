using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.DataModels
{
    public class UsersDataModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsManager { get; set; }
    }
}
