using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BackendSolution.Models;
using BetwayBackend.Interfaces;
using BetwayBackend.Request;

namespace BackendSolution.Services
{
    public class UserLoginService //:ILoginService
    {
        private readonly DbContext _dbContext;

        public UserLoginService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Boolean Login(UserRequest user)
        {
            UserLogin userLogin = _dbContext.Set<UserLogin>().Find(user.Username);
            if (userLogin != null&&user.Password==userLogin.Password)
            {
                return true;
            }
            return false;
        }


        public void PasswordReset(UserLogin userLogin)
        {
            _dbContext.Entry(userLogin).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void AddDetails(UserLogin userLogin)
        {
            throw new NotImplementedException();
        }
    }
}
