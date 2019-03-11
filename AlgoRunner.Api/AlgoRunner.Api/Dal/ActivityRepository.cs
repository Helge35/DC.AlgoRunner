using AlgoRunner.Api.Dal.EF;
using AlgoRunner.Api.Dal.EF.Entities;
using AlgoRunner.Api.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRunner.Api.Dal
{
    public class ActivityRepository
    {
        private readonly IMapper _mapper;
        private readonly AlgoRunnerDbContext _dbContext;

        public ActivityRepository(AlgoRunnerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        internal List<ActivityEntity> GetAllActivities()
        {
            return _dbContext.Activities.Select(x => _mapper.Map<ActivityEntity>(x)).ToList();
        }


        internal ActivityEntity AddActivity(ActivityEntity newActivity)
        {
            newActivity.Id = 1000;
            _dbContext.Activities.Add(_mapper.Map<Activity>(newActivity));
            _dbContext.SaveChanges();
            return newActivity;
        }

        internal void RemoveActivity(int id)
        {
            _dbContext.Activities.Remove(_dbContext.Activities.FirstOrDefault(x => x.Id == id));
            _dbContext.SaveChanges();
        }

        internal void UpdateCommonPath(string path)
        {
            _dbContext.Activities.First(x => x.Id < 0).ServerPath = path;
            _dbContext.SaveChanges();
        }

        internal string GetActivityPath(int activityID)
        {
           return _dbContext.Activities.First(x => x.Id == activityID).ServerPath;
        }
    }
}
