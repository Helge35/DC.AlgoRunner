using AlgoRunner.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Dal
{
    public class ActivityRepository
    {
        private List<ActivityEntity> _activities;

        public ActivityRepository()
        {
            _activities = new List<ActivityEntity> {
                new ActivityEntity{Id= -1, Name="Common", ServerPath=@"C:\\AlgoRunnerProjects\Common"},
                new ActivityEntity{Id= 1, Name="Big company project", ServerPath=@"C:\\AlgoRunnerProjects\Bp"},
                new ActivityEntity{Id= 2, Name="Small company project",ServerPath=@"C:\\AlgoRunnerProjects\Sp"},
                new ActivityEntity{Id= 3, Name="Restricted project",ServerPath=@"C:\Users\admin"},
            };

        }

        internal List<ActivityEntity> GetAllActivities()
        {
            return _activities;
        }


        internal ActivityEntity AddActivity(ActivityEntity newActivity)
        {
            newActivity.Id = 1000;
            _activities.Add(newActivity);
            return newActivity;
        }

        internal void RemoveActivity(int id)
        {
            _activities.Remove(_activities.FirstOrDefault(x => x.Id == id));
        }

        internal void UpdateCommonPath(string path)
        {
            _activities.First(x => x.Id < 0).ServerPath = path;
        }

        internal string GetActivityPath(int activityID)
        {
           return _activities.First(x => x.Id == activityID).ServerPath;
        }
    }
}
