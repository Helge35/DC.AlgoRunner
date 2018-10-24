using AlgoRunner.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Dal
{
    public class UsersRepository
    {
        private List<Activity> _activities;
        private List<User> _members;

        public UsersRepository()
        {
            _activities = new List<Activity> {
                new Activity{Id= 1, Name="Big company project"},
                new Activity{Id= 2, Name="Small company project"},
            };
            _members = new List<User> {
                   new User{Id=10, Name="User 10", IsAdmin=false, Activities= new List<Activity>{_activities.First()}},
                   new User{Id=10, Name="User 12",IsAdmin=false,  Activities= new List<Activity>{_activities.Last()}},
                   new User{Id=10, Name="User 14", IsAdmin=true,  Activities= new List<Activity>{_activities.First(), _activities.Last()}},
            };
        }

        internal List<User> GetAllMembers()
        {
            return _members;
        }

        internal List<Activity> GetAllActivities()
        {
            return _activities;
        }

        internal Activity AddActivity(string name)
        {
            _activities.Add(new Activity { Name = name, Id=1000});
            return new Activity { Name = name, Id = 1000 };
        }
    }
}
