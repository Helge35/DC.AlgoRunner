using AlgoRunner.Api.Dal.EF.Entities;
using AlgoRunner.Api.Entities;
using AutoMapper;

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
            CreateMap<ProjectAlgoEntity, ProjectAlgo>();
            CreateMap<ProjectEntity, Project>();
            CreateMap<UserEntity, User>();
            CreateMap<ProjectExecutionEntity, ProjectExecution>();
            CreateMap<ProjectExecution, ProjectExecutionEntity>();
            // CreateMap<Dal.EF.Entities.ExecutionResult, Dal.EF.Entities.ExecutionResult>();
        }
    }
}
