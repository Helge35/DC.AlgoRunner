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

        #region Executions

        internal List<ExecutionInfoEntity> SetAlgoExecutions(ProjectAlgoListEntity projectAlg, string executerName)
        {
            var projectExecution = new ProjectExecution { ExecutedBy = executerName };
            projectExecution.ExecutionInfos = new List<ExecutionInfo>();

            if (projectAlg.ProjectId > 0)
                projectExecution.ProjectId = projectAlg.ProjectId;

            var algoPaths = _dbContext.Algorithms.Include("Activity").Where(x => projectAlg.Algos.Select(y => y.Id).Contains(x.Id))
                .ToDictionary(o => o.Id, o => o.Activity.ServerPath);

            foreach (var algo in projectAlg.Algos)
            {
                var exeInfo = new ExecutionInfo();

                if (projectAlg.ProjectId > 0)
                    exeInfo.ProjectId = projectAlg.ProjectId;

                exeInfo.AlgoId = algo.Id;
                exeInfo.ExecutedBy = executerName;
                exeInfo.FileExePath = Path.Combine(algoPaths[algo.Id], algo.FileServerPath);
                exeInfo.ExeParams = algo.AlgoParams.Select(x => new AlgoExecutionParam { Name = x.Name, Value = x.Value }).ToList();
                exeInfo.ExecutionResult = EF.Entities.ExecutionResult.Pending;

                projectExecution.ExecutionInfos.Add(exeInfo);
            }

            _dbContext.ProjectExecutions.Add(projectExecution);
            _dbContext.SaveChanges();

            return projectExecution.ExecutionInfos.Select(x => _mapper.Map<ExecutionInfoEntity>(x)).ToList();
        }

        internal void StartAlgoExecution(int algoExeId, bool isFirstExecution)
        {
            var execution = _dbContext.ExecutionInfos.Include("ProjectExecution").First(x => x.Id == algoExeId);
            execution.StartDate = DateTime.Now;
            if (isFirstExecution)
                execution.ProjectExecution.StartDate = execution.StartDate.Value;

            _dbContext.SaveChanges();
        }

        internal void EndAlgoExecution(int algoExeId, string resultPath, bool isLastExecution)
        {
            var executionInfo = _dbContext.ExecutionInfos.Include("ProjectExecution").First(x => x.Id == algoExeId);
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
            var executionInfo = _dbContext.ExecutionInfos.First(x => x.Id == executionInfoId);
            executionInfo.FailureReason = failureMessage;
            executionInfo.ExecutionResult = EF.Entities.ExecutionResult.Failure;

            _dbContext.SaveChanges();
        }

        internal List<AlgorithmEntity> GetExecutionResults(int projeExeID) // ?? reuslt type ??? mapper ??
        {
            return _dbContext.ExecutionInfos
                .Include("ProjectExecution")
                .Include("Algorithm.ResultType")
                .Where(x => x.ProjectExecutionId == projeExeID && x.ExecutionResult == EF.Entities.ExecutionResult.Success).ToList()
                    .Select(x => _mapper.Map<AlgorithmEntity>(x.Algorithm)).ToList();
        }



        #endregion

        #region Algos
        internal string[] GetAlgFilePath(int projectID, int? algoID)
        {
            if (projectID == 0)
            {
                var algorithm = GetAlgorithm(algoID.Value);
                return new string[1] { Path.Combine(algorithm.Activity.ServerPath, algorithm.FileServerPath) };
            }

            return
                _dbContext.ProjectAlgos.Include("Algorithm")
                .Where(x => x.ProjectId == projectID)
                .Select(y => Path.Combine(y.Algorithm.Activity.ServerPath, y.Algorithm.FileServerPath)).Distinct().ToArray();
        }

        internal void AddNewAlg(AlgorithmEntity algorithmEntity)
        {
            var algorithm = _mapper.Map<Algorithm>(algorithmEntity);
            _dbContext.Algorithms.Add(algorithm);
            _dbContext.SaveChanges();
        }

        internal AlgorithmEntity GetAlgorithm(int id)
        {
            return _mapper.Map<AlgorithmEntity>(_dbContext.Algorithms
                .Include("Activity")
                .Include("ResultType")
                .Include("AlgoParams").First(x => x.Id == id));
        }

        #endregion

        internal void AddNewProject(ProjectEntity projectEntity)
        {
            var project = _mapper.Map<Project>(projectEntity);
            project.ActivityId = projectEntity.Activity.Id;

            project.ProjectAlgoList.Clear();
            var algorithms = _dbContext.Algorithms.Where(x => projectEntity.AlgorithmsList.Select(y => y.Id).Contains(x.Id));

            foreach (var algorithm in algorithms)
            {
                project.ProjectAlgoList.Add(new ProjectAlgo
                {
                    Algorithm = algorithm
                });
            }
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
        }

        internal List<AlgorithmEntity> GetProjectAlgorithms(int projectId)
        {
            //return _dbContext.ProjectAlgos
            //    .Include("Algorithm.Activity")
            //    .Include("Algorithm.ResultType")
            //    .Include("Algorithm.AlgoParams")
            //    .Where(x => x.ProjectId == projectId)
            //    .Select(x => _mapper.Map<AlgorithmEntity>(x.Algorithm)).ToList();

            var algosIds= _dbContext.ProjectAlgos
      .Where(x => x.ProjectId == projectId)
      .Select(x => x.Algorithm.Id).ToList();

            return _dbContext.Algorithms.Include("Activity")
                .Include("ResultType")
                .Include("AlgoParams")
                .Where(x => algosIds.Contains(x.Id))
                .Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
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

        internal List<AlgorithmEntity> GetAllAlgs()
        {
            return _dbContext.Algorithms
                .Include("Activity")
                .Include("ResultType")
                .Include("AlgoParams")
                .Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
        }

        internal ProjectEntity GetProject(int id)
        {
            var project = _dbContext.Projects
                .Include("ProjectExecutions")
                .Include("ProjectAlgoList.Algorithm")
                .Include("Activity")
                .First(x => x.Id == id);

            var projectEntity = _mapper.Map<ProjectEntity>(project);

            projectEntity.ProjectExecutions.ForEach(x => x.ResultPath = Path.GetFileName(x.ResultPath));
            return projectEntity;
        }

        internal void AddToFavorite(int projectID, string userName)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Name == userName);
            var vserFavoriteProject = _dbContext.UserFavoriteProjects.FirstOrDefault(x => x.ProjectId == projectID && x.UserId1 == user.Id);

            if (vserFavoriteProject == null)
                _dbContext.UserFavoriteProjects.Add(new UserFavoriteProject { User = user, ProjectId = projectID });
            else
                _dbContext.UserFavoriteProjects.Remove(vserFavoriteProject);

            _dbContext.SaveChanges();
        }


        internal IEnumerable<ProjectEntity> GetFavoritesProjects(string userName)
        {
            TryAddUser(userName);

            var projects = _dbContext.UserFavoriteProjects
                 .Include("Project.Activity")
                 .Include("User")
                 .Where(x => x.User.Name == userName).Select(x => x.Project).ToList();

            return _mapper.Map<List<ProjectEntity>>(projects);
        }

        internal bool TryAddUser(string userName)
        {
            try
            {
                if (_dbContext.Users.FirstOrDefault(x => x.Name == userName) == null)
                {
                    _dbContext.Users.Add(new User { Name = userName });
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        internal IEnumerable<ProjectEntity> GetResentProjects()
        {
            return _dbContext.Projects
                .Include("Activity")
                .OrderByDescending(x => x.LastExecutionDate)
                .Select(x => _mapper.Map<ProjectEntity>(x)).ToList();
        }

        internal IEnumerable<ProjectEntity> GetProjectsByPage(int pageNum, int pageSize, out int totalSize)
        {
            totalSize = _dbContext.Projects.Count();
            int from = pageSize * (pageNum - 1);
            var projects = _dbContext.Projects
                .Include("Activity")
                //.Include("ProjectAlgoList")
                //.Include("ProjectAlgoList.Algorithm")
                .Skip(from)
                .Take(pageSize)
                .Select(x => _mapper.Map<ProjectEntity>(x));

            return projects.ToList();
        }

        internal IEnumerable<ExecutionInfoEntity> GetExecutions()
        {
            return _dbContext.ExecutionInfos
                .Include("ProjectExecution")
                .Include("Project")
                .Include("Algorithm")
                .Where(x => !x.EndDate.HasValue)
                .Select(x => _mapper.Map<ExecutionInfoEntity>(x)).ToList();
        }
    }
}
