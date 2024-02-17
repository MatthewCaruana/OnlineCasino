using OnlineCasino.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Validations ValidateUser(string username, string password);
    }
}
