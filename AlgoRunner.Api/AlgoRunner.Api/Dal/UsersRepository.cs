using AlgoRunner.Api.Dal.EF;
using AlgoRunner.Api.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRunner.Api.Dal
{
    public class UsersRepository : RepositoryBase
    {
        public UsersRepository(AlgoRunnerDbContext dbContext, IMapper mapper, IHttpContextAccessor accessor) : base(dbContext, mapper, accessor) { }

        internal UserEntity GetUserInfo(string userName)
        {
            var userEntity = _mapper.Map<UserEntity>(_dbContext.Users                
                .FirstOrDefault(x => x.Name == userName));
            userEntity.Activities = _dbContext.Activities.Select(x => _mapper.Map<ActivityEntity>(x)).ToList();

            return userEntity;
        }

        internal List<UserEntity> GetAllMembers()
        {
            return _dbContext.Users                
                .Select(x => _mapper.Map<UserEntity>(x)).ToList();
        }
    }
}
