using AlgoRunner.Api.Dal.EF;
using AlgoRunner.Api.Dal.EF.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AlgoRunner.Api.Dal
{
    public class RepositoryBase
    {
        protected readonly IMapper _mapper;
        protected readonly AlgoRunnerDbContext _dbContext;
        protected readonly IHttpContextAccessor _accessor;        

        public RepositoryBase(AlgoRunnerDbContext dbContext, IMapper mapper, IHttpContextAccessor accessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _accessor = accessor;

            TryAddUser();
        }

        internal bool TryAddUser()
        {
            try
            {
                if (_accessor == null)
                    return false;

                var userName = _accessor.HttpContext.User.Identity.Name;

                if (_accessor != null && _dbContext.Users.FirstOrDefault(x => x.Name == userName) == null)
                {
                    _dbContext.Users.Add(new User { Name = userName });
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }        
    }
}
