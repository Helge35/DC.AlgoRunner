using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoRunner.Api.Entities;

namespace AlgoRunner.Api.Dal
{
    public class ProjectsRepository
    {

        public List<Algorithm> _algorithms;
        private List<Project> _projects;

        private List<AlgResultType> _algResultTypes;
        private List<Activity> _activities;

        private List<ExecutionInfo> _executionInfos;

        public ProjectsRepository(ActivityRepository activityRepository)
        {
            _activities = activityRepository.GetAllActivities();
            _algResultTypes = new List<AlgResultType>()
            {
                new AlgResultType{Id = 1, Name="Text"},
                new AlgResultType{Id = 2, Name="Table"},
                new AlgResultType{Id = 3, Name="Lines Graph"},
                new AlgResultType{Id = 4, Name="Pie Graph"},
                new AlgResultType{Id = 5, Name="Bars Graph"},
                new AlgResultType{Id = 6, Name="Dotes Graph"},
            };

            _algorithms = new List<Algorithm> {
                    new Algorithm{Id=110011,
                        Name ="Text Alg",
                        CreatedBy ="developer a1",
                        Desc ="Text Alg",
                        Activity = _activities.First() ,
                        ResultType = _algResultTypes.First(x=>x.Id == 1),
                        FileServerPath = @"C:\AlgoRunnerProjects\Bp\cacbb170-b2e1-4594-b46d-c2f439a3a5a4.py",
                        AlgoParams = new List<AlgoParam>{
                            new AlgoParam { Id = 501, Name="TimeOut", Type = new KeyValuePair<int, string>(1, "Number"), Range = new List<string>()},
                            new AlgoParam { Id = 502, Name="DemoStr", Type = new KeyValuePair<int, string>(2, "Text"), },
                            new AlgoParam { Id = 503, Name="Demo Boll", Type = new KeyValuePair<int, string>(3, "Boolean"), },
                            new AlgoParam { Id = 504, Name="Demo Enum", Type = new KeyValuePair<int, string>(4, "Enum"), Range=new List<string>{ "First", "Second", "Third" } },
                        }
                    },

                    new Algorithm{Id=1002,
                        Name ="Table Alg",
                        CreatedBy ="developer a1",
                        Desc ="1 Alg.............end",
                        Activity = _activities.First() ,
                        ResultType = _algResultTypes.First(x=>x.Id == 2),
                        FileServerPath = @"C:\AlgoRunnerProjects\Bp\6792778d-221d-4e81-8c36-b00ee12416a1.py",
                        AlgoParams = new List<AlgoParam>{
                        new AlgoParam { Id = 6011, Name="Num of rows", Type = new KeyValuePair<int, string>(1, "Number"), Range = new List<string>()}, }
                    },




                    new Algorithm{
                        Id =2, Name="Alg 2", CreatedBy="user a1", Desc="2 Alg.............end",Activity = _activities.First(), FileServerPath = @"C:\AlgoRunnerProjects\Bp\9b-9e41f2ecf398.bat",
                         ResultType = _algResultTypes.First(x=>x.Id == 2),
                    },
                    new Algorithm{Id=3, Name="Alg 3", CreatedBy="user a1", FileServerPath=@"C:\Users\admin\1111.bat",
                        Desc ="3 Alg.............end",Activity = _activities.First(x=>x.Id==3), ResultType = _algResultTypes.First(x=>x.Id == 4)},

                    new Algorithm{Id=4,
                        Name ="Scatter Alg",
                        CreatedBy ="developer a1",
                        Desc ="1 Alg.............end",
                        Activity = _activities.First(),
                        ResultType = _algResultTypes.First(x=>x.Id == 6),
                        FileServerPath = @"C:\AlgoRunnerProjects\Bp\6792778d-221d-4e81-8c36-b00ee12416a1.py",
                        AlgoParams = new List<AlgoParam>{
                            new AlgoParam { Id = 601, Name="Num of molec", Type = new KeyValuePair<int, string>(1, "Number"), Range = new List<string>()},
                        }
                    },

                    new Algorithm{Id=5, Name="Alg 5", CreatedBy="user a1", Desc="2 Alg.............end",Activity = _activities.Last()},
                    new Algorithm{Id=6, Name="Alg 6", CreatedBy="user a1", Desc="3 Alg.............end",Activity = _activities.Last()},
                    new Algorithm{Id=7, Name="Alg 7", CreatedBy="user a1", Desc="1 Alg.............end",Activity = _activities.Last()},
                    new Algorithm{Id=8, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=9, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=10, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=11, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=12, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=13, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=14, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=15, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=16, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=17, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},

            };

            _projects = new List<Project>
               {
                    new Project{Id = 1, Name= "Project 1", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 2, Name= "Project 2", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 3, Name= "Project 3", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 4, Name= "Project 4", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = true},
                    new Project{Id = 5, Name= "Project 5", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 6, Name= "Project 6", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = true},
                    new Project{Id = 7, Name= "Project 7", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 8, Name= "Project 8", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 9, Name= "Project 9", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = true , CreatedBy="Big baga boss",

                        //ExecutionsList =new List<ProjectExecution>{
                        //    new ProjectExecution{Id = 1, ExecutedBy ="User 55", StartDate = new DateTime(2018, 10, 1, 10, 0, 0),  EndDate = new DateTime(2018, 10, 1, 21, 0, 0), ResultPath="4_636825340445334012" },
                        //    new ProjectExecution{Id = 2, ExecutedBy ="User 1", StartDate = new DateTime(2018, 11, 1, 10, 0, 0),  EndDate = new DateTime(2018, 12, 1, 21, 0, 0) },
                        //    new ProjectExecution{Id = 3, ExecutedBy ="User 1", StartDate = new DateTime(2018, 12, 1, 10, 0, 0),  EndDate = new DateTime(2018, 12, 1, 21, 0, 0) },
                        //    new ProjectExecution{Id = 4, ExecutedBy ="User 2", StartDate = new DateTime(2018, 12, 11, 10, 0, 0),  EndDate = new DateTime(2018, 12, 15, 21, 0, 0) },
                        //    new ProjectExecution{Id = 5, ExecutedBy ="User 2", StartDate = new DateTime(2018, 12, 12, 10, 0, 0),  EndDate = new DateTime(2018, 12, 17, 21, 0, 0) },
                        //} ,

                        Desc ="Text start ...............................................................................................................................end",
                            AlgorithmsList = new List<Algorithm>{
                                    _algorithms.FirstOrDefault(x=>x.Id==110011),
                                    _algorithms.FirstOrDefault(x=>x.Id==1002),
                                    _algorithms.FirstOrDefault(x=>x.Id==4)
                            } , Activity = _activities.First()},
                    new Project{Id = 10, Name= "Project 10", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 11, Name= "Project 11", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 12, Name= "Project 12", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 13, Name= "Project 13", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 14, Name= "Project 14", LastExecutionDate= new DateTime(2018, 1,3), IsFavorite = false},
                    new Project{Id = 15, Name= "Project 15", LastExecutionDate= new DateTime(2018, 1,4), IsFavorite = false},
                    new Project{Id = 16, Name= "Project 16", LastExecutionDate= new DateTime(2018, 1,5), IsFavorite = false},
                    new Project{Id = 17, Name= "Project 17", LastExecutionDate= new DateTime(2018, 1,6), IsFavorite = true},
                    new Project{Id = 18, Name= "Project 18", LastExecutionDate= new DateTime(2018, 1,7), IsFavorite = false},
                    new Project{Id = 19, Name= "Project 19", LastExecutionDate= new DateTime(2018, 1,10), IsFavorite = false},

               };

            _executionInfos = new List<ExecutionInfo>
            {

                 new ExecutionInfo{Id = 1, ExecutedBy ="User 55", ProjectId=9, StartDate = new DateTime(2018, 10, 1, 10, 0, 0),  EndDate = new DateTime(2018, 10, 1, 21, 0, 0),  },
                            new ExecutionInfo{Id = 2, ExecutedBy ="User 1", StartDate = new DateTime(2018, 11, 1, 10, 0, 0),  EndDate = new DateTime(2018, 12, 1, 21, 0, 0) },
                            new ExecutionInfo{Id = 3, ExecutedBy ="User 1", StartDate = new DateTime(2018, 12, 1, 10, 0, 0),  EndDate = new DateTime(2018, 12, 1, 21, 0, 0) },
                            new ExecutionInfo{Id = 4, ExecutedBy ="User 2", StartDate = new DateTime(2018, 12, 11, 10, 0, 0),  EndDate = new DateTime(2018, 12, 15, 21, 0, 0) },
                            new ExecutionInfo{Id = 5, ExecutedBy ="User 2", StartDate = new DateTime(2018, 12, 12, 10, 0, 0),  EndDate = new DateTime(2018, 12, 17, 21, 0, 0) },

                //new ExecutionInfo{Id= 1001 , AlgoName = "Alg 5", ProjectName= "Finished", ExecutedBy="Big Boss", StartDate = DateTime.Now, EndDate= DateTime.Now.AddDays(1)},


                //new ExecutionInfo{Id= 35736970 , AlgoName = "Tester 1", AlgoId=4, ExecutedBy="Big Boss", StartDate = DateTime.Now, },
                //new ExecutionInfo{Id= 1001 , AlgoName = "Alg 4", ProjectName= "Proj 44", ExecutedBy="Big Boss", StartDate = DateTime.Now, },
                //new ExecutionInfo{Id= 1001 , AlgoName = "Alg ", ProjectName= "", ExecutedBy="Big Boss", StartDate = DateTime.Now, },
                //new ExecutionInfo{Id= 1001 , AlgoName = "Alg 6", ProjectName= "", ExecutedBy="Big Boss", StartDate = DateTime.Now, },
            };

        }

        internal Algorithm GetAlgorithmByAlgoExeId(int exeID)
        {
            return _algorithms.FirstOrDefault(a => _executionInfos.FirstOrDefault(x => x.Id == exeID).AlgoId == a.Id);
        }

        internal List<Algorithm> GetAlgorithmsByExecution(int projeExeID)
        {
            return _algorithms.Where(a => _executionInfos.Where(x => x.ProjectExecutionId == projeExeID).Select(x => x.AlgoId).Contains(a.Id)).ToList();
        }

        internal void EndAlgoExecution(int algoExeId, int projectExeID)
        {
            var execution = _executionInfos.First(x => x.Id == algoExeId);
            execution.EndDate = DateTime.Now;
            execution.ProjectExecutionId = projectExeID;
        }

        internal List<ExecutionInfo> SetAlgoExecutions(ProjectAlgoList projectAlg, string executerName)
        {
            List<ExecutionInfo> exeInfoList = new List<ExecutionInfo>();
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
                var exe = new ExecutionInfo
                {
                    Id = rand.Next(),
                    AlgoName = algo.Name,
                    ProjectId = projectID,
                    ProjectName = projectName,
                    StartDate = DateTime.Now,
                    ExecutedBy = executerName,
                    FileExePath = algo.FileServerPath,
                    AlgoId = algo.Id,
                    ExeParams = algo.AlgoParams.Select(x => new AlgoExecutionParams { Name = x.Name, Value = x.Value }).ToList()
                };
                exeInfoList.Add(exe);


                //AddNewAlg to db
                _executionInfos.Add(exe);

            }

            return exeInfoList;
        }

        internal List<Algorithm> GetAlgorithms(int[] algoIds)
        {
            return _algorithms.Where(a => algoIds.Contains(a.Id)).ToList();
        }

        internal List<Algorithm> GetProjectAlgorithms(int projectId)
        {
            return _projects.FirstOrDefault(x => x.Id == projectId)?.AlgorithmsList;
        }

        internal void AddNewProject(Project proj)
        {
            var rand = new Random().Next(1000);
            proj.Id = rand;
            _projects.Add(proj);
        }

        internal List<Algorithm> GetAllAlgs()
        {
            return _algorithms.ToList();
        }

        internal string[] GetAlgFilePath(ProjectAlgo projectAlgo)
        {
            if (projectAlgo.ProjectId == 0)
                return new string[1] { _algorithms.First(x => x.Id == projectAlgo.AlgoId).FileServerPath };
            else
                return _projects.First(x => x.Id == projectAlgo.ProjectId).AlgorithmsList.Select(y => y.FileServerPath).Distinct().ToArray();
        }

        internal void AddNewAlg(Algorithm algo)
        {
            _algorithms.Add(algo);
        }

        internal List<Algorithm> GetAlgsByPage(int pageNum, int algsPageSize, out int algsTotalSize)
        {
            algsTotalSize = _algorithms.Count;
            int from = algsPageSize * (pageNum - 1);
            return _algorithms.Skip(from).Take(algsPageSize).ToList();
        }

        internal Algorithm GetAlgorithm(int id)
        {
            return _algorithms.First(x => x.Id == id);
        }

        internal ExecutionInfo GetExecution(int id)
        {
            return _executionInfos.First(x => x.Id == id);
        }

        internal Project GetProject(int id)
        {
            var proj = _projects.First(x => x.Id == id);

            var execs = _executionInfos.Where(x => x.ProjectId == id).GroupBy(y => y.ProjectExecutionId);
            proj.ExecutionsList = new List<ExecutionInfo>();
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

        internal IEnumerable<Project> GetFavoritesProjects()
        {
            return _projects.Where(x => x.IsFavorite);
        }

        internal IEnumerable<Project> GetResentProjects()
        {
            return _projects.Where(x => x.LastExecutionDate > new DateTime(2018, 1, 1));
        }

        internal IEnumerable<Project> GetProjectsByPage(int pageNum, int pageSize, out int totalSize)
        {
            totalSize = _projects.Count;
            int from = pageSize * (pageNum - 1);
            return _projects.Skip(from).Take(pageSize);
        }

        internal IEnumerable<ExecutionInfo> GetExecutions()
        {
            return _executionInfos.Where(x => !x.EndDate.HasValue);
        }
    }
}
