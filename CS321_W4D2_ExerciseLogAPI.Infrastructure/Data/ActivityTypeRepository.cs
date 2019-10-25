using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CS321_W4D2_ExerciseLogAPI;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;


namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly AppDbContext _dbContext;
        public ActivityTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActivityType Add(ActivityType todo)
        {
            _dbContext.ActivityTypes.Add(todo);
            _dbContext.SaveChanges();
            return todo;
        }

        public ActivityType Get(int id)
        {
            return _dbContext.ActivityTypes.FirstOrDefault(at => at.Id == id);
        }

        public ActivityType Update(ActivityType updatedToDo)
        {
            var currentActivityType = this.Get(updatedToDo.Id);
            if (currentActivityType == null) return null;
            _dbContext.Entry(currentActivityType).CurrentValues.SetValues(updatedToDo);
            _dbContext.SaveChanges();
            return currentActivityType;
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return _dbContext.ActivityTypes.ToList();
        }

        public void Remove(ActivityType todo)
        {
            _dbContext.ActivityTypes.Remove(todo);
            _dbContext.SaveChanges();
        }


    }
}

