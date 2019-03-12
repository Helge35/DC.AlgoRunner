using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoRunner.Api.Dal.EF;
using AlgoRunner.Api.Dal.EF.Entities;
using AlgoRunner.Api.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlgoRunner.Api.Dal
{
    public class ProjectsRepository
    {
        private readonly IMapper _mapper;
        private readonly AlgoRunnerDbContext _dbContext;

        public ProjectsRepository(AlgoRunnerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        internal AlgorithmEntity GetAlgorithmByAlgoExeId(int exeID)
        {
            return _mapper.Map<AlgorithmEntity>(_dbContext.Algorithms.FirstOrDefault(a => _dbContext.ExecutionInfos.FirstOrDefault(x => x.Id == exeID).AlgoId == a.Id));
        }

        internal List<AlgorithmEntity> GetAlgorithmsByExecution(int projeExeID)
        {
            return _dbContext.Algorithms
                .Where(a => _dbContext.ExecutionInfos.Where(x => x.ProjectExecutionId == projeExeID)
                .Select(x => x.AlgoId).Contains(a.Id))
                .Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
        }

        internal void EndAlgoExecution(int algoExeId, int projectExeID)
        {
            var execution = _dbContext.ExecutionInfos.First(x => x.Id == algoExeId);
            execution.EndDate = DateTime.Now;
            execution.ProjectExecutionId = projectExeID;
            _dbContext.SaveChanges();
        }

        internal List<ExecutionInfoEntity> SetAlgoExecutions(ProjectAlgoListEntity projectAlg, string executerName)
        {
            List<ExecutionInfoEntity> exeInfoList = new List<ExecutionInfoEntity>();
            Random rand = new Random();

            int projectID = 0;
            string projectName = string.Empty;

            if (projectAlg.ProjectId > 0)
            {
                projectID = projectAlg.ProjectId;
                projectName = _dbContext.Projects.First(x => x.Id == projectAlg.ProjectId).Name;
            }

            foreach (var algo in projectAlg.Algos)
            {
                var exe = new ExecutionInfoEntity
                {
                    Id = rand.Next(),
                    AlgoName = algo.Name,
                    ProjectId = projectID,
                    ProjectName = projectName,
                    StartDate = DateTime.Now,
                    ExecutedBy = executerName,
                    FileExePath = algo.FileServerPath,
                    AlgoId = algo.Id,
                    ExeParams = algo.AlgoParams.Select(x => new AlgoExecutionParamEntity { Name = x.Name, Value = x.Value }).ToList()
                };
                exeInfoList.Add(exe);

                //AddNewAlg to db
                _dbContext.ExecutionInfos.Add(_mapper.Map<ExecutionInfo>(exe));

            }

            return exeInfoList;
        }

        internal List<AlgorithmEntity> GetAlgorithms(int[] algoIds)
        {
            return _dbContext.Algorithms
                .Where(a => algoIds.Contains(a.Id))
                .Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
        }

        internal List<AlgorithmEntity> GetProjectAlgorithms(int projectId)
        {
            return _dbContext.Projects
                .Include("AlgorithmsList")
                .FirstOrDefault(x => x.Id == projectId)?.AlgorithmsList
                .Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
        }

        internal void AddNewProject(ProjectEntity proj)
        {
            var rand = new Random().Next(1000);
            proj.Id = rand;
            _dbContext.Projects.Add(_mapper.Map<Project>(proj));
        }

        internal List<AlgorithmEntity> GetAllAlgs()
        {
            return _dbContext.Algorithms
                .Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
        }

        internal string[] GetAlgFilePath(ProjectAlgoEntity projectAlgo)
        {
            if (projectAlgo.ProjectId == 0)
                return new string[1] { _dbContext.Algorithms.First(x => x.Id == projectAlgo.AlgoId).FileServerPath };
            else
                return _dbContext.Projects
                    .First(x => x.Id == projectAlgo.ProjectId)
                    .AlgorithmsList
                    .Select(y => y.FileServerPath).Distinct().ToArray();
        }

        internal void AddNewAlg(AlgorithmEntity algo)
        {
            _dbContext.Algorithms.Add(_mapper.Map<Algorithm>(algo));
            _dbContext.SaveChanges();
        }

        internal List<AlgorithmEntity> GetAlgsByPage(int pageNum, int algsPageSize, out int algsTotalSize)
        {
            algsTotalSize = _dbContext.Algorithms.Count();
            int from = algsPageSize * (pageNum - 1);
            return _dbContext.Algorithms
                .Include("AlgoParams")
                .Skip(from)
                .Take(algsPageSize)
                .Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
        }

        internal AlgorithmEntity GetAlgorithm(int id)
        {
            return _mapper.Map<AlgorithmEntity>(_dbContext.Algorithms.First(x => x.Id == id));
        }

        internal ExecutionInfoEntity GetExecution(int id)
        {
            return _mapper.Map<ExecutionInfoEntity>(_dbContext.ExecutionInfos.First(x => x.Id == id));
        }

        internal ProjectEntity GetProject(int id)
        {
            var proj = _dbContext.Projects.First(x => x.Id == id);
            var execs = _dbContext.ExecutionInfos
                .Where(x => x.ProjectId == id)
                .GroupBy(y => y.ProjectExecutionId);
            proj.ExecutionsList = new List<ExecutionInfo>();
            foreach (var exe in execs)
            {
                var projectExe = exe.FirstOrDefault();
                projectExe.StartDate = exe.Min(x => x.StartDate);
                projectExe.EndDate = exe.Max(x => x.EndDate);
                proj.ExecutionsList.Add(projectExe);
            }

            return _mapper.Map<ProjectEntity>(proj);
        }

        internal void AddToFavorite(int projectID)
        {
            var proj = _dbContext.Projects.First(x => x.Id == projectID);
            proj.IsFavorite = !proj.IsFavorite;
            _dbContext.SaveChanges();
        }

        internal IEnumerable<ProjectEntity> GetFavoritesProjects()
        {
            return _dbContext.Projects
                .Include("Activity")
                .Where(x => x.IsFavorite)
                .Select(x => _mapper.Map<ProjectEntity>(x));
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
            return _dbContext.Projects
                .Skip(from)
                .Take(pageSize)
                .Select(x => _mapper.Map<ProjectEntity>(x));           
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
