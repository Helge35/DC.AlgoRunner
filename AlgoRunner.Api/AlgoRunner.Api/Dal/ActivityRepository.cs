using AlgoRunner.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Dal
{
    public class ActivityRepository
    {
        private List<Activity> _activities;

        public ActivityRepository()
        {
            _activities = new List<Activity> {
                new Activity{Id= 1, Name="Big company project", ServerPath=@"C:\\AlgoRunnerProjects\Bp"},
                new Activity{Id= 2, Name="Small company project",ServerPath=@"C:\\AlgoRunnerProjects\Sp"},
                new Activity{Id= 3, Name="Restricted project",ServerPath=@"C:\Users\admin"},
            };

        }

        internal List<Activity> GetAllActivities()
        {
            return _activities;
        }


        internal Activity AddActivity(Activity newActivity)
        {
            newActivity.Id = 1000;
            _activities.Add(newActivity);
            return newActivity;
        }

        internal void RemoveActivity(int id)
        {
            _activities.Remove(_activities.FirstOrDefault(x => x.Id == id));
        }

        internal string GetActivityPath(int activityID)
        {
           return _activities.First(x => x.Id == activityID).ServerPath;
        }
    }
}
