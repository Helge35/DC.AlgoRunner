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
                   new User{Id=101, Name="User 10", IsAdmin=false, Activities= new List<Activity>{_activities.First()}},
                   new User{Id=102, Name="User 12",IsAdmin=false,  Activities= new List<Activity>{_activities.Last()}},
                   new User{Id=103, Name="User 14", IsAdmin=true,  Activities= new List<Activity>{_activities.First(), _activities.Last()}},
                   new User{Id=104, Name=@"DESKTOP-KM9M96J\Oleg",IsAdmin=true,  Activities= new List<Activity>{_activities.Last()}},
                   
            };
        }

        internal User GetUserInfo(string userName)
        {
            return _members.FirstOrDefault(x => x.Name == userName);
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

        internal void RemoveActivity(int id)
        {
            _activities.Remove(_activities.FirstOrDefault(x => x.Id == id));
        }
    }
}
