using AlgoRunner.Api.Dal.EF;
using AlgoRunner.Api.Dal.EF.Entities;
using AlgoRunner.Api.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRunner.Api.Dal
{
    public class ActivityRepository : RepositoryBase
    {        
        public ActivityRepository(AlgoRunnerDbContext dbContext, IMapper mapper, IHttpContextAccessor accessor) : base(dbContext, mapper, accessor) { }

        internal List<ActivityEntity> GetAllActivities()
        {
            return _dbContext.Activities
                .Select(x => _mapper.Map<ActivityEntity>(x)).ToList();
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
            var executionInfos = _dbContext.ExecutionInfos.Where(x => x.Algorithm.Activity.Id == id || x.Project.Activity.Id == id);
            foreach(var executionInfo in executionInfos)
                _dbContext.AlgoExecutionParams.RemoveRange(executionInfo.ExeParams);

            _dbContext.ExecutionInfos.RemoveRange(executionInfos);
            _dbContext.Projects.RemoveRange(_dbContext.Projects.Where(x => x.Activity.Id == id));
            _dbContext.Algorithms.RemoveRange(_dbContext.Algorithms.Where(x => x.Activity.Id == id));
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
