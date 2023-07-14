using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BackendSolution.Models;

namespace BackendSolution.Services
{
    public class OtptokenService
    {
        private readonly DbContext _dbContext;

        public OtptokenService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Otptoken> GetAll()
        {
            return _dbContext.Set<Otptoken>().ToList();
        }

        public Otptoken GetById(Guid id)
        {
            return _dbContext.Set<Otptoken>().Find(id);
        }

        public void Add(Otptoken otptoken)
        {
            _dbContext.Set<Otptoken>().Add(otptoken);
            _dbContext.SaveChanges();
        }

        public void Update(Otptoken otptoken)
        {
            _dbContext.Entry(otptoken).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var otptoken = _dbContext.Set<Otptoken>().Find(id);
            if (otptoken != null)
            {
                _dbContext.Set<Otptoken>().Remove(otptoken);
                _dbContext.SaveChanges();
            }
        }
    }
}
