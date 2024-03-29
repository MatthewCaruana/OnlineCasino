﻿using OnlineCasino.Application.DTOs;
using OnlineCasino.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Application.Services.Interfaces
{
    public interface IAuthService
    {
        public Validations AttemptLogin(LoginRequestDTO loginRequest);
    }
}
