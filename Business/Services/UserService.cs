using Business.Models;
using Business.Results;
using Business.Results.Basis;
using Business.Services.Basis;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService : IUserService
    {

        private readonly Db _db;

        public UserService(Db db)
        {
            _db = db;
        }

        public Result Add(UserModel model)
        {
            if (_db.Users.Any(u => u.UserName.ToUpper() == model.UserName.ToUpper().Trim()))
            {
                return new FailureResult("User with same user name exists");
            }


            User user = new User()
            {
                UserName = model.UserName,
                Password = model.Password,
                Email = model.Email,
            };
            _db.Users.Add(user);
            _db.SaveChanges();

            return new SuccessResult("User added successfully!");
        }

        //public Result DeleteUser(UserModel model)
        //{
        //    //var userEntity = _db.Users.Include(u => u.UserResources).SingleOrDefault(u => u.Id == id);
        //    //if (userEntity == null)
        //    //{
        //    //    return new FailureResult("User not found");
        //    //}

        //    //_db.UserResources.RemoveRange(userEntity.UserResources);
        //    //_db.Users.Remove(userEntity);
        //    //_db.SaveChanges();

        //    //return new SuccessResult("User deleted successfully");
        //}

        public IQueryable<UserModel> Query()
        {
            return _db.Users.OrderBy(u => u.UserName).Select(u => new UserModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Password = u.Password
            });
        }

        public Result Update(UserModel model)
        {
            List<User> existingUser = _db.Users.ToList();
            if (existingUser.Any(u => u.UserName.Equals(model.UserName.Trim(), StringComparison.OrdinalIgnoreCase) && u.Id != model.Id))
            {
                return new FailureResult("User with same user name exists");
            }

            var user = _db.Users.SingleOrDefault(u => u.Id == model.Id);

            if (user is not null)
            {
                user.UserName = model.UserName.Trim();
                user.Password = model.Password.Trim();
                user.Email = model.Email.Trim();

                _db.Users.Update(user);

                _db.SaveChanges();

            }
            return new SuccessResult("User updated successfully");
        }
    }
}
