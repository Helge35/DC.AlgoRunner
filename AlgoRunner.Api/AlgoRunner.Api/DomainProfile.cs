using AlgoRunner.Api.Dal.EF.Entities;
using AlgoRunner.Api.Entities;
using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {            
            CreateMap<ActivityEntity, Activity>();
            CreateMap<AlgoExecutionParamEntity, AlgoExecutionParam>();
            CreateMap<AlgoParamEntity, AlgoParam>();
            CreateMap<AlgorithmEntity, Algorithm>();
            CreateMap<AlgResultTypeEntity, AlgResultType>();
            CreateMap<ExecutionInfoEntity, ExecutionInfo>();
            CreateMap<MessageEntity, ExecutionInfo>();
            CreateMap<ProjectAlgoEntity, ProjectEntity>();
            CreateMap<ProjectAlgoListEntity, ProjectAlgoList>();
            CreateMap<ProjectEntity, Project>();
            CreateMap<ProjectExecutionEntity, ProjectExecution>();
            CreateMap<RoleEntity, Role>();
            CreateMap<UserEntity, User>();           
        }
    }
}
