using Business.Models;
using Business.Results.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Basis
{
    public interface IUserService
    {
        IQueryable<UserModel> Query();

        Result Add(UserModel model);

        Result Update(UserModel model);

        //Result DeleteUser(UserModel model);
    }
}
