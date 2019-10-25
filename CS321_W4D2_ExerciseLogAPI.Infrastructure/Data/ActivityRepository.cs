using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CS321_W4D2_ExerciseLogAPI;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository : IActivityRepository
    {
        
            private readonly AppDbContext _dbContext;
            public ActivityRepository(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Activity Add(Activity todo)
            {
                _dbContext.Activities.Add(todo);
                _dbContext.SaveChanges();
                return todo;
            }

            public Activity Get(int id)
            {
                return _dbContext.Activities.FirstOrDefault(u => u.Id == id);
            }

            public Activity Update(Activity updatedToDo)
            {
                var currentActivity = this.Get(updatedToDo.Id);
                if (currentActivity == null) return null;
                _dbContext.Entry(currentActivity).CurrentValues.SetValues(updatedToDo);
                _dbContext.SaveChanges();
                return currentActivity;
            }

            public IEnumerable<Activity> GetAll()
            {
            return _dbContext.Activities.ToList();
            }

            public void Remove(Activity todo)
            {
                _dbContext.Activities.Remove(todo);
                _dbContext.SaveChanges();
            }


        }
    }

