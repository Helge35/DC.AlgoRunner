using AlgoRunner.Api.Dal.EF;
using AlgoRunner.Api.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRunner.Api.Dal
{
    public class UsersRepository
    {
        private readonly IMapper _mapper;
        private readonly AlgoRunnerDbContext _dbContext;

        public UsersRepository(AlgoRunnerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        internal UserEntity GetUserInfo(string userName)
        {
            return _mapper.Map<UserEntity>(_dbContext.Users.FirstOrDefault(x => x.Name == userName));
        }

        internal List<UserEntity> GetAllMembers()
        {
            return _dbContext.Users
                .Select(x => _mapper.Map<UserEntity>(x)).ToList();
        }
    }
}
