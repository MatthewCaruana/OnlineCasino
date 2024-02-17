using OnlineCasino.Application.DTOs;
using OnlineCasino.Application.Services.Interfaces;
using OnlineCasino.Persistence.Context.Interfaces;
using OnlineCasino.Persistence.Repositories.Interfaces;
using OnlineCasino.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.Services
{
    public class AuthService : IAuthService
    {
        private IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public Validations AttemptLogin(LoginRequestDTO loginRequest)
        {
            return _repository.ValidateUser(loginRequest.Username, loginRequest.Password);
       
        }
    }
}
