using OnlineCasino.Persistence.Context.Interfaces;
using OnlineCasino.Persistence.DataModels;
using OnlineCasino.Persistence.Repositories.Interfaces;
using OnlineCasino.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private IOnlineCasinoDbContext _context;

        public AuthRepository(IOnlineCasinoDbContext context)
        {
            _context = context;
        }

        public Validations ValidateUser(string username, string password)
        {
            try
            {
                UsersDataModel user = _context.Users.Where(x => x.Username == username).FirstOrDefault();

                if (user != null)
                {
                    if(user.Password == password)
                    {
                        return Validations.FOUND; 
                    }
                    return Validations.INCORRECT_PASSWORD;
                }
                return Validations.UNKNOWN_USERNAME;    
            }
            catch
            {
                return Validations.SYSTEM_ERROR;
            }
        }
    }
}
