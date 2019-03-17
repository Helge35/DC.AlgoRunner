using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        internal AlgorithmEntity GetAlgorithmByAlgoExeId(int exeID)
        {
            return _mapper.Map<AlgorithmEntity>(_dbContext.Algorithms
                .Include("ResultType")
                .FirstOrDefault(a => _dbContext.ExecutionInfos.FirstOrDefault(x => x.Id == exeID).AlgoId == a.Id));
        }

        internal List<AlgorithmEntity> GetAlgorithmsByExecution(int projeExeID)
        {
            return _dbContext.Algorithms
                .Include("ResultType")
                .Where(a => _dbContext.ExecutionInfos.Where(x => x.Id == projeExeID)
                .Select(x => x.AlgoId).Contains(a.Id))
                .Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
        }

        internal void StartAlgoExecution(int algoExeId)
        {
            var execution = _dbContext.ExecutionInfos                
                .First(x => x.Id == algoExeId).StartDate = DateTime.Now;
            _dbContext.SaveChanges();
        }

        internal void EndAlgoExecution(int algoExeId, string resultPath)
        {
            var endTime = DateTime.Now;
            var execution = _dbContext.ExecutionInfos
                .First(x => x.Id == algoExeId);
            execution.EndDate = endTime;            
            _dbContext.SaveChanges();
        }

        internal List<ExecutionInfoEntity> SetAlgoExecutions(ProjectAlgoListEntity projectAlg, string executerName)
        {                  
            var project = _dbContext.Projects
                .Include("Activity")
                .FirstOrDefault(x => x.Id == projectAlg.ProjectId);

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
                    StartDate = DateTime.Now,
                    ExecutedBy = executerName,
                    FileExePath = Path.Combine(algorithm.Activity.ServerPath, algo.FileServerPath),
                    ExeParams = algo.AlgoParams.Select(x => new AlgoExecutionParam { Name = x.Name, Value = x.Value }).ToList()
                });
            }

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
            return _mapper.Map<ProjectEntity>(_dbContext.Projects
                .Include("ExecutionsList")
                .Include("ProjectAlgoList")
                .Include("ProjectAlgoList.Algorithm")
                .Include("Activity")
                .First(x => x.Id == id));                      
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
                .Include("Project")
                .Include("Algorithm")                 
                .Where(x => !x.EndDate.HasValue)
                .Select(x => _mapper.Map<ExecutionInfoEntity>(x));
        }
    }
}
