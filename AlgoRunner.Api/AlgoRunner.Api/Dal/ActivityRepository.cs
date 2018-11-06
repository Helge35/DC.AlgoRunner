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
            };

        }

        internal List<Activity> GetAllActivities()
        {
            return _activities;
        }

        internal Activity AddActivity(string name)
        {
            _activities.Add(new Activity { Name = name, Id = 1000 });
            return new Activity { Name = name, Id = 1000 };
        }

        internal void RemoveActivity(int id)
        {
            _activities.Remove(_activities.FirstOrDefault(x => x.Id == id));
        }
    }
}
