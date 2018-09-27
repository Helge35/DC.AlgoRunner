using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoRunner.Api.Entities;

namespace AlgoRunner.Api.Dal
{
    public class ProjectsRepository
    {
        public ProjectsRepository()
        {
            projects = new List<Project>
               {
                    new Project{Id = 1, Name= "Project 1", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 2, Name= "Project 2", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 3, Name= "Project 3", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 4, Name= "Project 4", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = true},
                    new Project{Id = 5, Name= "Project 5", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 6, Name= "Project 6", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = true},
                    new Project{Id = 7, Name= "Project 7", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 8, Name= "Project 8", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = true},
                    new Project{Id = 9, Name= "Project 9", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 10, Name= "Project 10", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 11, Name= "Project 11", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 12, Name= "Project 12", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 13, Name= "Project 13", LastExecutionDate= new DateTime(2018, 1,1), IsFavorite = false},
                    new Project{Id = 14, Name= "Project 14", LastExecutionDate= new DateTime(2018, 1,3), IsFavorite = false},
                    new Project{Id = 15, Name= "Project 15", LastExecutionDate= new DateTime(2018, 1,4), IsFavorite = false},
                    new Project{Id = 16, Name= "Project 16", LastExecutionDate= new DateTime(2018, 1,5), IsFavorite = false},
                    new Project{Id = 17, Name= "Project 17", LastExecutionDate= new DateTime(2018, 1,6), IsFavorite = true},
                    new Project{Id = 18, Name= "Project 18", LastExecutionDate= new DateTime(2018, 1,7), IsFavorite = false},

               };
        }

        private List<Project> projects;

        internal void AddToFavorite(int projectID)
        {
            var proj = projects.First(x => x.Id == projectID);
            proj.IsFavorite = !proj.IsFavorite;
        }

        internal IEnumerable<Project> GetFavoritesProjects()
        {
            return projects.Where(x => x.IsFavorite);
        }

        internal IEnumerable<Project> GetResentProjects()
        {
            return projects.Where(x => x.LastExecutionDate > new DateTime(2018, 1, 1));
        }

        internal IEnumerable<Project> GetProjectsByPage(int pageNum, int pageSize, out int totalSize)
        {
            totalSize = projects.Count;
            int from = pageSize * (pageNum - 1);
            return projects.Skip(from).Take(pageSize);
        }
    }
}
