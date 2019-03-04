using AlgoRunner.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Dal
{
    public class UsersRepository
    {
        private List<UserEntity> _members;
        private List<ActivityEntity> _activities;

        public UsersRepository(ActivityRepository activityRepository)
        {
            _activities = activityRepository.GetAllActivities();
            _members = new List<UserEntity> {
                   new UserEntity{Id=101, Name="User 10", IsAdmin=false, Activities= new List<ActivityEntity>{_activities.First()}},
                   new UserEntity{Id=102, Name="User 12",IsAdmin=false,  Activities= new List<ActivityEntity>{_activities.Last()}},
                   new UserEntity{Id=103, Name="User 14", IsAdmin=true,  Activities= new List<ActivityEntity>{_activities.First(), _activities.Last()}},
                   new UserEntity{Id=104, Name=@"RF\OLEGBR",IsAdmin=true,  Activities= new List<ActivityEntity>{_activities.Last()}},
                   
            };
        }

        internal UserEntity GetUserInfo(string userName)
        {
            return _members.FirstOrDefault(x => x.Name == userName);
        }

        internal List<UserEntity> GetAllMembers()
        {
            return _members;
        }


    }
}
