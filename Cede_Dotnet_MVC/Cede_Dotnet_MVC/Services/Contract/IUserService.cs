using Cede_Dotnet_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cede_Dotnet_MVC.Services.Contract
{
    public interface IUserService
    {
        User GetUserByUserId(string userId);
        string ValidateUserByNitAndNitDate(string nit, DateTime nitDate);
        List<User> GetUsers();
    }
}