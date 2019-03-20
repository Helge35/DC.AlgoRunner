using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgoRunner.Api.Dal.EF;
using AlgoRunner.Api.Dal.EF.Entities;
using AlgoRunner.Api.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AlgoRunner.Api.Dal
{
    public class ProjectsRepository : RepositoryBase
    {
        public ProjectsRepository(AlgoRunnerDbContext dbContext, IMapper mapper, IHttpContextAccessor accessor) : base(dbContext, mapper, accessor) { }
        
        internal List<AlgorithmEntity> GetAlgorithmsByExecution(int projeExeID)
        {
            return _dbContext.ExecutionInfos
                .Include("ProjectExecution")
                .Include("Algorithm")
                .Include("Algorithm.ResultType")
                .Where(x => x.ProjectExecutionId == projeExeID && x.ExecutionResult == EF.Entities.ExecutionResult.Success).ToList()
                    .Select(x => _mapper.Map<AlgorithmEntity>(x.Algorithm)).ToList();            
        }

        internal void StartAlgoExecution(int algoExeId, bool isFirstExecution)
        {
            var execution = _dbContext.ExecutionInfos
                .Include("ProjectExecution")
                .First(x => x.Id == algoExeId);
            execution.StartDate = DateTime.Now;
            if (isFirstExecution)
                execution.ProjectExecution.StartDate = execution.StartDate.Value;
            
            _dbContext.SaveChanges();
        }

        internal void EndAlgoExecution(int algoExeId, string resultPath, bool isLastExecution)
        {
            var executionInfo = _dbContext.ExecutionInfos
                .Include("ProjectExecution")
                .First(x => x.Id == algoExeId);
            executionInfo.EndDate = DateTime.Now;
            if (isLastExecution)
            {
                executionInfo.ProjectExecution.EndDate = executionInfo.EndDate.Value;
                executionInfo.ProjectExecution.ResultPath = resultPath;
            }

            if (executionInfo.ExecutionResult == EF.Entities.ExecutionResult.Pending)
                executionInfo.ExecutionResult = EF.Entities.ExecutionResult.Success;

            _dbContext.SaveChanges();
        }

        internal void SetExecutionFailure(int executionInfoId, string failureMessage)
        {
            var executionInfo = _dbContext.ExecutionInfos
                .First(x => x.Id == executionInfoId);
            executionInfo.FailureReason = failureMessage;
            executionInfo.ExecutionResult = EF.Entities.ExecutionResult.Failure;

            _dbContext.SaveChanges();
        }

        internal List<ExecutionInfoEntity> SetAlgoExecutions(ProjectAlgoListEntity projectAlg, string executerName)
        {                  
            var project = _dbContext.Projects
                .Include("Activity")
                .FirstOrDefault(x => x.Id == projectAlg.ProjectId);

            var projectExecution = new ProjectExecution { ExecutedBy = executerName };
            var executionsList = new List<ExecutionInfo>();
            foreach (var algo in projectAlg.Algos)
            {
                var algorithm = _dbContext.Algorithms
                    .Include("Activity")
                    .FirstOrDefault(x => x.Id == algo.Id);

                executionsList.Add(new ExecutionInfo
                {
                    Project = project,
                    Algorithm = algorithm,                    
                    ExecutedBy = executerName,
                    FileExePath = Path.Combine(algorithm.Activity.ServerPath, algo.FileServerPath),
                    ExeParams = algo.AlgoParams.Select(x => new AlgoExecutionParam { Name = x.Name, Value = x.Value }).ToList(),
                    ProjectExecution = projectExecution,
                    ExecutionResult = EF.Entities.ExecutionResult.Pending
                });
            }

            _dbContext.ProjectExecutions.Add(projectExecution);
            _dbContext.ExecutionInfos.AddRange(executionsList);
            _dbContext.SaveChanges();

            return executionsList.Select(x => _mapper.Map<ExecutionInfoEntity>(x)).ToList();
        }

        internal List<AlgorithmEntity> GetAlgorithms(int[] algoIds)
        {
            return _dbContext.Algorithms
                .Include("Activity")
                .Include("ResultType")
                .Include("AlgoParams")
                .Where(a => algoIds.Contains(a.Id))
                .Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
        }

        internal List<AlgorithmEntity> GetProjectAlgorithms(int projectId)
        {
            return _dbContext.Projects
                .Include("ProjectAlgoList")
                .Include("ProjectAlgoList.Algorithm")
                .Include("ProjectAlgoList.Algorithm.Activity")
                .Include("ProjectAlgoList.Algorithm.ResultType")
                .Include("ProjectAlgoList.Algorithm.AlgoParams")                
                .FirstOrDefault(x => x.Id == projectId)?.ProjectAlgoList
                .Select(x => _mapper.Map<AlgorithmEntity>(x.Algorithm)).ToList();
        }

        internal void AddNewProject(ProjectEntity projectEntity)
        {
            var project = _mapper.Map<Project>(projectEntity);
            project.Activity = _dbContext.Activities.FirstOrDefault(x => x.Id == projectEntity.Activity.Id);
            project.ProjectAlgoList.Clear();
            var algorithms = _dbContext.Algorithms
                .Where(x => projectEntity.AlgorithmsList
                .Select(y => y.Id).Contains(x.Id));
            foreach (var algorithm in algorithms)
            {
                project.ProjectAlgoList.Add(new ProjectAlgo
                {
                    Project = project,
                    Algorithm = algorithm
                });
            }
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
        }

        internal List<AlgorithmEntity> GetAllAlgs()
        {
            return _dbContext.Algorithms
                .Include("Activity")
                .Include("ResultType")
                .Include("AlgoParams")
                .Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
        }

        internal string[] GetAlgFilePath(ProjectAlgoEntity projectAlgo)
        {
            if (projectAlgo.ProjectId == 0)
            {
                var algorithm = GetAlgorithm(projectAlgo.AlgoId);
                return new string[1] { Path.Combine(algorithm.Activity.ServerPath, algorithm.FileServerPath) };                
            }
            
            var project = GetProject(projectAlgo.ProjectId);
            return project.AlgorithmsList
                .Select(y => Path.Combine(project.Activity.ServerPath, y.FileServerPath)).Distinct().ToArray();           
        }

        internal string[] GetAlgosFilePath(ProjectAlgoListEntity projectAlgoList)
        {
            if (projectAlgoList.ProjectId == 0)
            {
                var algorithm = GetAlgorithm(projectAlgoList.Algos.First().Id);
                return new string[1] { Path.Combine(algorithm.Activity.ServerPath, algorithm.FileServerPath) };
            }

            var project = _dbContext.Projects
                .Include("Activity")
                .Include("ProjectAlgoList")
                .Include("ProjectAlgoList.Algorithm")
                .Where(x => x.Id == projectAlgoList.ProjectId).First();
            return project.ProjectAlgoList
                .Where(x => projectAlgoList.Algos
                .Select(y => y.Id)
                .Contains(x.Algorithm.Id))
                .Select(x => Path.Combine(project.Activity.ServerPath, x.Algorithm.FileServerPath)).ToArray();            
        }

        internal void AddNewAlg(AlgorithmEntity algorithmEntity)
        {
            var algorithm = _mapper.Map<Algorithm>(algorithmEntity);
            algorithm.ResultType = _dbContext.AlgResultTypes.FirstOrDefault(x => x.Name == algorithmEntity.ResultType.Name);
            algorithm.Activity = _dbContext.Activities.FirstOrDefault(x => x.Id == algorithmEntity.Activity.Id);
            _dbContext.Algorithms.Add(algorithm);
            _dbContext.SaveChanges();
        }

        internal List<AlgorithmEntity> GetAlgsByPage(int pageNum, int algsPageSize, out int algsTotalSize)
        {
            algsTotalSize = _dbContext.Algorithms.Count();
            int from = algsPageSize * (pageNum - 1);
            return _dbContext.Algorithms
                .Include("Activity")
                .Include("ResultType")
                .Include("AlgoParams")
                .Skip(from)
                .Take(algsPageSize)
                .Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
        }

        internal AlgorithmEntity GetAlgorithm(int id)
        {
            return _mapper.Map<AlgorithmEntity>(_dbContext.Algorithms
                .Include("Activity")
                .Include("ResultType")
                .Include("AlgoParams").First(x => x.Id == id));
        }

        internal ExecutionInfoEntity GetExecution(int id)
        {
            return _mapper.Map<ExecutionInfoEntity>(_dbContext.ExecutionInfos.First(x => x.Id == id));
        }

        internal ProjectEntity GetProject(int id)
        {
            var project = _dbContext.Projects       
                .Include("ExecutionsList")
                .Include("ExecutionsList.ProjectExecution")
                .Include("ProjectAlgoList")
                .Include("ProjectAlgoList.Algorithm")
                .Include("Activity")
                .First(x => x.Id == id);

            var projectEntity = _mapper.Map<ProjectEntity>(project);
            var projectExecutions = project.ExecutionsList
                .Select(x => x.ProjectExecution)
                .Distinct();

            var executionInfoList = new List<ExecutionInfoEntity>();            
            foreach (var projectExecution in projectExecutions)
            {
                #region Aggrigate all failure reasons
                var failureReason = string.Empty;
                var executionInfoFailureReasonList = project.ExecutionsList
                    .Where(x => x.ProjectExecutionId == projectExecution.Id && !string.IsNullOrEmpty(x.FailureReason))
                    .Select(x => x.FailureReason).ToList();

                for (int i = 0; i < executionInfoFailureReasonList.Count(); i++)
                {
                    if (i == 0)
                        failureReason += $@"Execution failure reason(s):{Environment.NewLine}";

                    failureReason += $@"{i + 1}) {executionInfoFailureReasonList[i]}";

                    if (i < executionInfoFailureReasonList.Count() - 1)
                        failureReason += Environment.NewLine;
                }
                #endregion

                #region Aggrigate all execution results
                var executionInfoResultList = project.ExecutionsList
                    .Where(x => x.ProjectExecutionId == projectExecution.Id)
                    .Select(x => x.ExecutionResult);

                var executionInfoResult = Entities.ExecutionResult.PartialSuccess;
                if (executionInfoResultList.All(x=>x == EF.Entities.ExecutionResult.Failure))
                    executionInfoResult = Entities.ExecutionResult.Failure;
                else if (executionInfoResultList.All(x => x == EF.Entities.ExecutionResult.Success))
                    executionInfoResult = Entities.ExecutionResult.Success;
                #endregion

                executionInfoList.Add(new ExecutionInfoEntity
                {
                    Id = projectExecution.Id,
                    StartDate = projectExecution.StartDate,
                    EndDate = projectExecution.EndDate,
                    ExecutedBy = projectExecution.ExecutedBy,
                    ProjectId = project.Id,
                    ProjectExecutionId = projectExecution.Id,
                    ExecutionResult = executionInfoResult,
                    FailureReason = failureReason
                });
            }

            projectEntity.ExecutionsList = executionInfoList;
            return projectEntity;
        }

        internal void AddToFavorite(int projectID, string userName)
        {
            var project = _dbContext.Projects.First(x => x.Id == projectID);
            var user = _dbContext.Users.FirstOrDefault(x => x.Name == userName);
            var userFavoriteProject = GetUserFavoriteProjects()
                .FirstOrDefault(x => x.Project.Id == projectID);
            if (userFavoriteProject == null)
                _dbContext.UserFavoriteProjects.Add(new UserFavoriteProject { User = user, Project = project });
            else
                _dbContext.UserFavoriteProjects.Remove(userFavoriteProject);
            
            _dbContext.SaveChanges();
        }

        private IEnumerable<UserFavoriteProject> GetUserFavoriteProjects()
        {
            return _dbContext.UserFavoriteProjects
                .Include("User")
                .Include("Project")
                .Where(x => x.User.Name == _accessor.HttpContext.User.Identity.Name);
        }

        internal IEnumerable<ProjectEntity> GetFavoritesProjects(string userName)
        {
            var user = _dbContext.Users
                .Include("UserFavoriteProjectList")
                .Include("UserFavoriteProjectList.Project")
                .FirstOrDefault(x => x.Name == userName);                

            return user.UserFavoriteProjectList
                .Select(x => _mapper.Map<ProjectEntity>(x.Project));
        }

        internal IEnumerable<ProjectEntity> GetResentProjects()
        {
            return _dbContext.Projects
                .Where(x => x.LastExecutionDate > new DateTime(2018, 1, 1))
                .Select(x => _mapper.Map<ProjectEntity>(x));
        }

        internal IEnumerable<ProjectEntity> GetProjectsByPage(int pageNum, int pageSize, out int totalSize)
        {
            totalSize = _dbContext.Projects.Count();
            int from = pageSize * (pageNum - 1);
            var projects = _dbContext.Projects
                .Include("Activity")
                .Include("ProjectAlgoList")
                .Include("ProjectAlgoList.Algorithm")
                .Skip(from)
                .Take(pageSize)
                .Select(x => _mapper.Map<ProjectEntity>(x));

            UpdateFavoriteProject(projects);

            return projects;
        }

        private void UpdateFavoriteProject(IEnumerable<ProjectEntity> projectEntities)
        {
            foreach (var userFavoriteProject in GetUserFavoriteProjects())
                foreach (var projectEntity in projectEntities)
                    if (projectEntity.Id == userFavoriteProject.Project.Id)
                        projectEntity.IsFavorite = true;
        }

        internal IEnumerable<ExecutionInfoEntity> GetExecutions()
        {
            return _dbContext.ExecutionInfos
                .Include("ProjectExecution")
                .Include("Project")
                .Include("Algorithm")                 
                .Where(x => !x.EndDate.HasValue)
                .Select(x => _mapper.Map<ExecutionInfoEntity>(x));
        }
    }
}
