//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AlgoRunner.Api.Dal.EF;
//using AlgoRunner.Api.Dal.EF.Entities;
//using AlgoRunner.Api.Entities;
//using AutoMapper;

//namespace AlgoRunner.Api.Dal
//{
//    public class ProjectsRepository
//    {
//        private readonly AlgoRunnerDbContext _context;
//        private readonly IMapper _mapper;

//        public ProjectsRepository(AlgoRunnerDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;


//        }

//        internal AlgorithmEntity GetAlgorithmByAlgoExeId(int exeID)
//        {
//            var res = _context.ExecutionInfos.FirstOrDefault(x => x.ID == exeID).Algorithm;
//            return _mapper.Map<AlgorithmEntity>(res);
//        }

//        internal List<AlgorithmEntity> GetAlgorithmsByExecution(int projeExeID)
//        {
//            var res = _context.ExecutionInfos.Where(x => x.ProjectExecutionID == projeExeID).Select(x => x.Algorithm);
//            return _mapper.Map<List<AlgorithmEntity>>(res);
//        }

//        internal void EndAlgoExecution(int algoExeId, int projectExeID)
//        {
//            var execution = _context.ExecutionInfos.First(x => x.ID == algoExeId);
//            execution.EndDate = DateTime.Now;
//            execution.ProjectExecutionID = projectExeID;
//            _context.SaveChanges();
//        }

//        internal List<ExecutionInfoEntity> SetAlgoExecutions(ProjectAlgoList projectAlg, string executerName)
//        {
//            List<ExecutionInfo> exeInfoList = new List<ExecutionInfo>();
//            string projectName = string.Empty;

//            if (projectAlg.ProjectId > 0)
//                _context.Projects.FirstOrDefault(x => x.ID == projectAlg.ProjectId).LastExecutionDate = DateTime.Now;

//            foreach (var algo in projectAlg.Algos)
//            {
//                var exe = new ExecutionInfo
//                {
//                    AlgoID = algo.Id,
//                    StartDate = DateTime.Now,
//                    ExecutedBy = executerName,
//                    FileExePath = algo.FileServerPath,
//                    AlgoExecutionParams = new List<AlgoExecutionParam>(),
//                };

//                if (projectAlg.ProjectId > 0)
//                    exe.ProjectID = projectAlg.ProjectId;

//                if (algo.AlgoParams != null && algo.AlgoParams.Count > 0)
//                {
//                    foreach (var param in algo.AlgoParams)
//                    {
//                        exe.AlgoExecutionParams.Add(new AlgoExecutionParam { Name = param.Name, Value = param.Value });
//                    }
//                }

//                exeInfoList.Add(exe);
//                _context.ExecutionInfos.Add(exe);

//            }

//            _context.SaveChanges();
//            return _mapper.Map<List<ExecutionInfoEntity>>(exeInfoList);
//        }

//        internal List<AlgorithmEntity> GetAlgorithms(int[] algoIds)
//        {
//            var res = _context.Algorithms.Where(a => algoIds.Contains(a.ID)).ToList();
//            return _mapper.Map<List<AlgorithmEntity>>(res);
//        }

//        internal List<AlgorithmEntity> GetProjectAlgorithms(int projectId)
//        {
//            var res = _context.ProjectsAlgs.Where(x => x.ProjectID == projectId).Select(x => x.Algorithm);
//            return _mapper.Map<List<AlgorithmEntity>>(res);
//        }

//        internal void AddNewProject(ProjectEntity proj)
//        {
//            var projectDto = _mapper.Map<Project>(proj);
//            _context.Projects.Add(projectDto);
//            _context.SaveChanges();
//        }

//        internal List<AlgorithmEntity> GetAllAlgs()
//        {
//            var res = _context.Algorithms.ToList();
//            return _mapper.Map<List<AlgorithmEntity>>(res);
//        }

//        internal string[] GetAlgFilePath(ProjectAlgo projectAlgo)
//        {
//            if (projectAlgo.ProjectId == 0)
//                return new string[1] { _context.Algorithms.First(x => x.ID == projectAlgo.AlgoId).FileServerPath };
//            else
//                return _context.ProjectsAlgs.Where(x => x.ProjectID == projectAlgo.ProjectId).Select(x => x.Algorithm).Select(y => y.FileServerPath).Distinct().ToArray();
//        }

//        internal void AddNewAlg(AlgorithmEntity algo)
//        {
//            var algtDto = _mapper.Map<Algorithm>(algo);
//            _context.Algorithms.Add(algtDto);
//            _context.SaveChanges();
//        }

//        internal List<AlgorithmEntity> GetAlgsByPage(int pageNum, int algsPageSize, out int algsTotalSize)
//        {
//            algsTotalSize = _context.Algorithms.Count();
//            int from = algsPageSize * (pageNum - 1);
//            var res = _context.Algorithms.Skip(from).Take(algsPageSize).ToList();
//            return _mapper.Map<List<AlgorithmEntity>>(res);
//        }

//        internal AlgorithmEntity GetAlgorithm(int id)
//        {
//            var res = _context.Algorithms.First(x => x.ID == id);
//            return _mapper.Map<AlgorithmEntity>(res);
//        }

//        internal ExecutionInfo GetExecution(int id)
//        {
//            return _context.ExecutionInfos.First(x => x.ID == id);
//        }

//        internal ProjectEntity GetProject(int id)
//        {
//            var proj = _context.Projects.First(x => x.ID == id);
//            return _mapper.Map<ProjectEntity>(proj);
//        }

//        internal void AddToFavorite(int projectID)
//        {
//            var proj = _context.Projects.First(x => x.ID == projectID);
//            proj.IsFavorite = !proj.IsFavorite;
//            _context.SaveChanges();
//        }

//        internal IEnumerable<ProjectEntity> GetFavoritesProjects()
//        {
//            var proj = _context.Projects.Where(x => x.IsFavorite.Value);
//            return _mapper.Map<IEnumerable<ProjectEntity>>(proj);
//        }

//        internal IEnumerable<ProjectEntity> GetResentProjects()
//        {
//            var proj = _context.Projects.OrderBy(x => x.LastExecutionDate).Take(6);
//            return _mapper.Map<IEnumerable<ProjectEntity>>(proj);
//        }

//        internal IEnumerable<ProjectEntity> GetProjectsByPage(int pageNum, int pageSize, out int totalSize)
//        {
//            totalSize = _context.Projects.Count();
//            int from = pageSize * (pageNum - 1);
//            var projs = _context.Projects.Skip(from).Take(pageSize);
//            return _mapper.Map<IEnumerable<ProjectEntity>>(projs);
//        }

//        internal IEnumerable<ExecutionInfoEntity> GetExecutions()
//        {
//            var res = _context.ExecutionInfos.Where(x => !x.EndDate.HasValue);
//            return _mapper.Map<IEnumerable<ExecutionInfoEntity>>(res);
//        }
//    }
//}
