using AlgoRunner.Api.Dal.EF.Entities;
using AlgoRunner.Api.Entities;
using AutoMapper;
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
            CreateMap<AdminInfoEntity, AdminInfo>();
            CreateMap<AlgoDotesResultEntity, AlgoDotesResult>();
            CreateMap<AlgoExecutionParamEntity, AlgoExecutionParam>();
            CreateMap<AlgoParamEntity, AlgoParam>();
            CreateMap<AlgorithmEntity, Algorithm>();
            CreateMap<AlgoTableResultEntity, AlgoTableResult>();
            CreateMap<AlgoTextResultEntity, AlgoTextResult>();
            CreateMap<AlgResultTypeEntity, AlgResultType>();
            //CreateMap<DashboardInfoEntity, DashboardInfo>();
            CreateMap<ExecutionInfoEntity, ExecutionInfo>();
            CreateMap<MessageEntity, ExecutionInfo>();
            CreateMap<PointEntity, Point>();
            CreateMap<ProjectAlgoEntity, ProjectEntity>();
            CreateMap<ProjectAlgoListEntity, ProjectAlgoList>();
            CreateMap<ProjectEntity, Project>();
            CreateMap<ProjectExecutionEntity, ProjectExecution>();
            CreateMap<ResultCategoryEntity, ResultCategory>();
            CreateMap<RoleEntity, Role>();
            CreateMap<UserEntity, User>();
        }
    }
}
