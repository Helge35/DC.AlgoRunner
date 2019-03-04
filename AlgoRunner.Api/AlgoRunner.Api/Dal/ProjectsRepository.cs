using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoRunner.Api.Dal.EF;
using AlgoRunner.Api.Entities;
using AutoMapper;

namespace AlgoRunner.Api.Dal
{
    public class ProjectsRepository
    {

        public List<AlgorithmEntity> _algorithms;
        private List<ProjectEntity> _projects;

        private List<AlgResultTypeEntity> _algResultTypes;
        private List<ActivityEntity> _activities;

        private List<ExecutionInfoEntity> _executionInfos;

        public ProjectsRepository(ActivityRepository activityRepository)
        {
            _activities = activityRepository.GetAllActivities();
            _algResultTypes = new List<AlgResultTypeEntity>()
            {
                new AlgResultTypeEntity{Id = 1, Name="Text"},
                new AlgResultTypeEntity{Id = 2, Name="Table"},
                new AlgResultTypeEntity{Id = 3, Name="Lines Graph"},
                new AlgResultTypeEntity{Id = 4, Name="Pie Graph"},
                new AlgResultTypeEntity{Id = 5, Name="Bars Graph"},
                new AlgResultTypeEntity{Id = 6, Name="Dotes Graph"},
            };

            _algorithms = new List<AlgorithmEntity> {
                    new AlgorithmEntity{Id=110011,
                        Name ="Text Alg",
                        CreatedBy ="developer a1",
                        Desc ="Text Alg",
                        Activity = _activities.First() ,
                        ResultType = _algResultTypes.First(x=>x.Id == 1),
                        FileServerPath = @"C:\AlgoRunnerProjects\Bp\cacbb170-b2e1-4594-b46d-c2f439a3a5a4.py",
                        AlgoParams = new List<AlgoParamEntity>{
                            new AlgoParamEntity { Id = 501, Name="TimeOut", Type = new KeyValuePair<int, string>(1, "Number"), Range = new List<string>()},
                            new AlgoParamEntity { Id = 502, Name="DemoStr", Type = new KeyValuePair<int, string>(2, "Text"), },
                            new AlgoParamEntity { Id = 503, Name="Demo Boll", Type = new KeyValuePair<int, string>(3, "Boolean"), },
                            new AlgoParamEntity { Id = 504, Name="Demo Enum", Type = new KeyValuePair<int, string>(4, "Enum"), Range=new List<string>{ "First", "Second", "Third" } },
                        }
                    },

                    new AlgorithmEntity{Id=1002,
                        Name ="Table Alg",
                        CreatedBy ="developer a1",
                        Desc ="1 Alg.............end",
                        Activity = _activities.First() ,
                        ResultType = _algResultTypes.First(x=>x.Id == 2),
                        FileServerPath = @"C:\AlgoRunnerProjects\Bp\6792778d-221d-4e81-8c36-b00ee12416a1.py",
                        AlgoParams = new List<AlgoParamEntity>{
                        new AlgoParamEntity { Id = 6011, Name="Num of rows", Type = new KeyValuePair<int, string>(1, "Number"), Range = new List<string>()}, }
                    },




                    new AlgorithmEntity{
                        Id =2, Name="Alg 2", CreatedBy="user a1", Desc="2 Alg.............end",Activity = _activities.First(), FileServerPath = @"C:\AlgoRunnerProjects\Bp\9b-9e41f2ecf398.bat",
                         ResultType = _algResultTypes.First(x=>x.Id == 2),
                    },
                    new AlgorithmEntity{Id=3, Name="Alg 3", CreatedBy="user a1", FileServerPath=@"C:\Users\admin\1111.bat",
                        Desc ="3 Alg.............end",Activity = _activities.First(x=>x.Id==3), ResultType = _algResultTypes.First(x=>x.Id == 4)},

                    new AlgorithmEntity{Id=4,
                        Name ="Scatter Alg",
                        CreatedBy ="developer a1",
                        Desc ="1 Alg.............end",
                        Activity = _activities.First(),
                        ResultType = _algResultTypes.First(x=>x.Id == 6),
                        FileServerPath = @"C:\AlgoRunnerProjects\Bp\6792778d-221d-4e81-8c36-b00ee12416a1.py",
                        AlgoParams = new List<AlgoParamEntity>{
                            new AlgoParamEntity { Id = 601, Name="Num of molec", Type = new KeyValuePair<int, string>(1, "Number"), Range = new List<string>()},
                        }
                    },

                    new AlgorithmEntity{Id=5, Name="Alg 5", CreatedBy="user a1", Desc="2 Alg.............end",Activity = _activities.Last()},
                    new AlgorithmEntity{Id=6, Name="Alg 6", CreatedBy="user a1", Desc="3 Alg.............end",Activity = _activities.Last()},
                    new AlgorithmEntity{Id=7, Name="Alg 7", CreatedBy="user a1", Desc="1 Alg.............end",Activity = _activities.Last()},
                    new AlgorithmEntity{Id=8, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new AlgorithmEntity{Id=9, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new AlgorithmEntity{Id=10, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new AlgorithmEntity{Id=11, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new AlgorithmEntity{Id=12, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new AlgorithmEntity{Id=13, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new AlgorithmEntity{Id=14, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new AlgorithmEntity{Id=15, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new AlgorithmEntity{Id=16, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new AlgorithmEntity{Id=17, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},

            };

            _projects = new List<ProjectEntity>
               {
                    new ProjectEntity{Name= "Project 1", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new ProjectEntity{Name= "Project 2", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new ProjectEntity{Name= "Project 3", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new ProjectEntity{Name= "Project 4", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = true},
                    new ProjectEntity{Name= "Project 5", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new ProjectEntity{Name= "Project 6", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = true},
                    new ProjectEntity{Name= "Project 7", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new ProjectEntity{Name= "Project 8", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new ProjectEntity{Name= "Project 9", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = true , CreatedBy="Big baga boss",

                        //ExecutionsList =new List<ProjectExecution>{
                        //    new ProjectExecution{Id = 1, ExecutedBy ="User 55", StartDate = new DateTime(2018, 10, 1, 10, 0, 0),  EndDate = new DateTime(2018, 10, 1, 21, 0, 0), ResultPath="4_636825340445334012" },
                        //    new ProjectExecution{Id = 2, ExecutedBy ="User 1", StartDate = new DateTime(2018, 11, 1, 10, 0, 0),  EndDate = new DateTime(2018, 12, 1, 21, 0, 0) },
                        //    new ProjectExecution{Id = 3, ExecutedBy ="User 1", StartDate = new DateTime(2018, 12, 1, 10, 0, 0),  EndDate = new DateTime(2018, 12, 1, 21, 0, 0) },
                        //    new ProjectExecution{Id = 4, ExecutedBy ="User 2", StartDate = new DateTime(2018, 12, 11, 10, 0, 0),  EndDate = new DateTime(2018, 12, 15, 21, 0, 0) },
                        //    new ProjectExecution{Id = 5, ExecutedBy ="User 2", StartDate = new DateTime(2018, 12, 12, 10, 0, 0),  EndDate = new DateTime(2018, 12, 17, 21, 0, 0) },
                        //} ,

                        Desc ="Text start ...............................................................................................................................end",
                            AlgorithmsList = new List<AlgorithmEntity>{
                                    _algorithms.FirstOrDefault(x=>x.Id==110011),
                                    _algorithms.FirstOrDefault(x=>x.Id==1002),
                                    _algorithms.FirstOrDefault(x=>x.Id==4)
                            } , Activity = _activities.First()},
                    new ProjectEntity{Name= "Project 10", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new ProjectEntity{Name= "Project 11", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new ProjectEntity{Name= "Project 12", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new ProjectEntity{Name= "Project 13", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new ProjectEntity{Name= "Project 14", LastExecutionDate= new DateTime(2018, 1,3), IsFavorite = false},
                    new ProjectEntity{Name= "Project 15", LastExecutionDate= new DateTime(2018, 1,4), IsFavorite = false},
                    new ProjectEntity{Name= "Project 16", LastExecutionDate= new DateTime(2018, 1,5), IsFavorite = false},
                    new ProjectEntity{Name= "Project 17", LastExecutionDate= new DateTime(2018, 1,6), IsFavorite = true},
                    new ProjectEntity{Name= "Project 18", LastExecutionDate= new DateTime(2018, 1,7), IsFavorite = false},
                    new ProjectEntity{Name= "Project 19", LastExecutionDate= new DateTime(2018, 1,10), IsFavorite = false},

               };

            _executionInfos = new List<ExecutionInfoEntity>
            {

                 new ExecutionInfoEntity{Id = 1, ExecutedBy ="User 55", ProjectId=9, StartDate = new DateTime(2018, 10, 1, 10, 0, 0),  EndDate = new DateTime(2018, 10, 1, 21, 0, 0),  },
                            new ExecutionInfoEntity{Id = 2, ExecutedBy ="User 1", StartDate = new DateTime(2018, 11, 1, 10, 0, 0),  EndDate = new DateTime(2018, 12, 1, 21, 0, 0) },
                            new ExecutionInfoEntity{Id = 3, ExecutedBy ="User 1", StartDate = new DateTime(2018, 12, 1, 10, 0, 0),  EndDate = new DateTime(2018, 12, 1, 21, 0, 0) },
                            new ExecutionInfoEntity{Id = 4, ExecutedBy ="User 2", StartDate = new DateTime(2018, 12, 11, 10, 0, 0),  EndDate = new DateTime(2018, 12, 15, 21, 0, 0) },
                            new ExecutionInfoEntity{Id = 5, ExecutedBy ="User 2", StartDate = new DateTime(2018, 12, 12, 10, 0, 0),  EndDate = new DateTime(2018, 12, 17, 21, 0, 0) },

                //new ExecutionInfo{Id= 1001 , AlgoName = "Alg 5", ProjectName= "Finished", ExecutedBy="Big Boss", StartDate = DateTime.Now, EndDate= DateTime.Now.AddDays(1)},


                //new ExecutionInfo{Id= 35736970 , AlgoName = "Tester 1", AlgoId=4, ExecutedBy="Big Boss", StartDate = DateTime.Now, },
                //new ExecutionInfo{Id= 1001 , AlgoName = "Alg 4", ProjectName= "Proj 44", ExecutedBy="Big Boss", StartDate = DateTime.Now, },
                //new ExecutionInfo{Id= 1001 , AlgoName = "Alg ", ProjectName= "", ExecutedBy="Big Boss", StartDate = DateTime.Now, },
                //new ExecutionInfo{Id= 1001 , AlgoName = "Alg 6", ProjectName= "", ExecutedBy="Big Boss", StartDate = DateTime.Now, },
            };

        }

        internal AlgorithmEntity GetAlgorithmByAlgoExeId(int exeID)
        {
            return _algorithms.FirstOrDefault(a => _executionInfos.FirstOrDefault(x => x.Id == exeID).AlgoId == a.Id);
        }

        internal List<AlgorithmEntity> GetAlgorithmsByExecution(int projeExeID)
        {
            return _algorithms.Where(a => _executionInfos.Where(x => x.ProjectExecutionId == projeExeID).Select(x => x.AlgoId).Contains(a.Id)).ToList();
        }

        internal void EndAlgoExecution(int algoExeId, int projectExeID)
        {
            var execution = _executionInfos.First(x => x.Id == algoExeId);
            execution.EndDate = DateTime.Now;
            execution.ProjectExecutionId = projectExeID;
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
                projectName = _projects.First(x => x.Id == projectAlg.ProjectId).Name;
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
                _executionInfos.Add(exe);

            }

            return exeInfoList;
        }

        internal List<AlgorithmEntity> GetAlgorithms(int[] algoIds)
        {
            return _algorithms.Where(a => algoIds.Contains(a.Id)).ToList();
        }

        internal List<AlgorithmEntity> GetProjectAlgorithms(int projectId)
        {
            return _projects.FirstOrDefault(x => x.Id == projectId)?.AlgorithmsList;
        }

        internal void AddNewProject(ProjectEntity proj)
        {
            var rand = new Random().Next(1000);
            proj.Id = rand;
            _projects.Add(proj);
        }

        internal List<AlgorithmEntity> GetAllAlgs()
        {
            return _algorithms.ToList();
        }

        internal string[] GetAlgFilePath(ProjectAlgoEntity projectAlgo)
        {
            if (projectAlgo.ProjectId == 0)
                return new string[1] { _algorithms.First(x => x.Id == projectAlgo.AlgoId).FileServerPath };
            else
                return _projects.First(x => x.Id == projectAlgo.ProjectId).AlgorithmsList.Select(y => y.FileServerPath).Distinct().ToArray();
        }

        internal void AddNewAlg(AlgorithmEntity algo)
        {
            _algorithms.Add(algo);
        }

        internal List<AlgorithmEntity> GetAlgsByPage(int pageNum, int algsPageSize, out int algsTotalSize)
        {
            algsTotalSize = _algorithms.Count;
            int from = algsPageSize * (pageNum - 1);
            return _algorithms.Skip(from).Take(algsPageSize).ToList();
        }

        internal AlgorithmEntity GetAlgorithm(int id)
        {
            return _algorithms.First(x => x.Id == id);
        }

        internal ExecutionInfoEntity GetExecution(int id)
        {
            return _executionInfos.First(x => x.Id == id);
        }

        internal ProjectEntity GetProject(int id)
        {
            var proj = _projects.First(x => x.Id == id);

            var execs = _executionInfos.Where(x => x.ProjectId == id).GroupBy(y => y.ProjectExecutionId);
            proj.ExecutionsList = new List<ExecutionInfoEntity>();
            foreach (var exe in execs)
            {
                var projectExe = exe.FirstOrDefault();
                projectExe.StartDate = exe.Min(x => x.StartDate);
                projectExe.EndDate = exe.Max(x => x.EndDate);
                proj.ExecutionsList.Add(projectExe);
            }

            //proj.ExecutionsList = _executionInfos.Where(x => x.ProjectId == id).GroupBy(y=>y.ProjectExecutionId).Select(x=>x.FirstOrDefault()).ToList();
            return proj;
        }

        internal void AddToFavorite(int projectID)
        {
            var proj = _projects.First(x => x.Id == projectID);
            proj.IsFavorite = !proj.IsFavorite;
        }

        internal IEnumerable<ProjectEntity> GetFavoritesProjects()
        {
            return _projects.Where(x => x.IsFavorite);
        }

        internal IEnumerable<ProjectEntity> GetResentProjects()
        {
            return _projects.Where(x => x.LastExecutionDate > new DateTime(2018, 1, 1));
        }

        internal IEnumerable<ProjectEntity> GetProjectsByPage(int pageNum, int pageSize, out int totalSize)
        {
            totalSize = _projects.Count;
            int from = pageSize * (pageNum - 1);
            return _projects.Skip(from).Take(pageSize);
        }

        internal IEnumerable<ExecutionInfoEntity> GetExecutions()
        {
            return _executionInfos.Where(x => !x.EndDate.HasValue);
        }
    }
}
