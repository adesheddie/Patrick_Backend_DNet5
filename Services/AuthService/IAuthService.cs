using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg_project.Models;

namespace Rpg_project.Services.AuthService
{
    public interface IAuthService
    {
        
        public Task<ServiceResponse<int>> Register (string email,string password);

        public Task <ServiceResponse<Users>> Login (string email,string password);

        public Task <bool> CheckIfExists (string email);
    }
}