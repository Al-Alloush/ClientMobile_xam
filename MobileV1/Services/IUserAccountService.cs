using MobileV1.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileV1.Services
{
    interface IUserAccountService
    {
        Task<UserLogined> Login(LoginModel loginF);
    }
}
