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
            };

            _algorithms = new List<Algorithm> {
                    new Algorithm{Id=1, Name="Alg 1", CreatedBy="user a1", Desc="1 Alg.............end", Activity = _activities.First() ,ResultType = _algResultTypes.First(x=>x.Id == 1),},
                    new Algorithm{
                        Id =2, Name="Alg 2", CreatedBy="user a1", Desc="2 Alg.............end",Activity = _activities.First(),
                         ResultType = _algResultTypes.First(x=>x.Id == 2),
                    },
                    new Algorithm{Id=3, Name="Alg 3", CreatedBy="user a1", Desc="3 Alg.............end",Activity = _activities.First(), ResultType = _algResultTypes.First(x=>x.Id == 4)},
                    new Algorithm{Id=1, Name="Alg 4", CreatedBy="user a1", Desc="1 Alg.............end",Activity = _activities.Last()},
                    new Algorithm{Id=2, Name="Alg 5", CreatedBy="user a1", Desc="2 Alg.............end",Activity = _activities.Last()},
                    new Algorithm{Id=3, Name="Alg 6", CreatedBy="user a1", Desc="3 Alg.............end",Activity = _activities.Last()},
                    new Algorithm{Id=1, Name="Alg 7", CreatedBy="user a1", Desc="1 Alg.............end",Activity = _activities.Last()},
                    new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},

                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
                     new Algorithm{Id=2, Name="Alg 8 common", CreatedBy="user a1", Desc="2 Alg.............end"},
                    new Algorithm{Id=3, Name="Alg 9 common", CreatedBy="user a1", Desc="3 Alg.............end"},
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
                    new Project{Id = 9, Name= "Project 9", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = true , CreatedBy="Big baga boss", ExecutionsList =new List<ProjectExecution>{
                            new ProjectExecution{Id = 1, ExecutedBy ="User 1", StartDate = new DateTime(2018, 10, 1, 10, 0, 0),  EndDate = new DateTime(2018, 10, 1, 21, 0, 0) },
                            new ProjectExecution{Id = 2, ExecutedBy ="User 1", StartDate = new DateTime(2018, 11, 1, 10, 0, 0),  EndDate = new DateTime(2018, 12, 1, 21, 0, 0) },
                            new ProjectExecution{Id = 3, ExecutedBy ="User 1", StartDate = new DateTime(2018, 12, 1, 10, 0, 0),  EndDate = new DateTime(2018, 12, 1, 21, 0, 0) },
                            new ProjectExecution{Id = 4, ExecutedBy ="User 2", StartDate = new DateTime(2018, 12, 11, 10, 0, 0),  EndDate = new DateTime(2018, 12, 15, 21, 0, 0) },
                            new ProjectExecution{Id = 5, ExecutedBy ="User 2", StartDate = new DateTime(2018, 12, 12, 10, 0, 0),  EndDate = new DateTime(2018, 12, 17, 21, 0, 0) },
                        } , Desc="Text start ...............................................................................................................................end",
                            AlgorithmsList = new List<Algorithm>{
                                    _algorithms[0],
                                    _algorithms[1],
                                    _algorithms[2],
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
        }


        internal List<Algorithm> GetAlgsByPage(int pageNum, int algsPageSize, out int algsTotalSize)
        {
            algsTotalSize = _algorithms.Count;
            int from = algsPageSize * (pageNum - 1);
            return _algorithms.Skip(from).Take(algsPageSize).ToList();
        }

        internal Project GetProject(int id)
        {
            return _projects.First(x => x.Id == id);
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
    }
}
