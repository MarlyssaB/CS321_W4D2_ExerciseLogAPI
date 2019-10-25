
using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository

    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User newUser)
        {
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return newUser;
        }

        public User Get(int id)
        {
            return _dbContext.Users
                .Include(User => User.Activities)
                .SingleOrDefault(user => user.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users
                .Include(user => user.Activities)
                .ToList();
        }

        public void Remove(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public User Update(User updatedUser)
        {
            var currentUser = _dbContext.Users.FirstOrDefault(x => x.Id == updatedUser.Id);

            if (currentUser == null) return null;

            _dbContext.Entry(currentUser)
                .CurrentValues
                .SetValues(updatedUser);

            _dbContext.Update(currentUser);
            _dbContext.SaveChanges();
            return currentUser;
        }
        public IEnumerable<User> GetActivitiesforUser(int userId)
        {
            return _dbContext.Users
                .Include(user => user.Activities)
                .Where(u => u.Id == userId).ToList();
        }
    }
}
