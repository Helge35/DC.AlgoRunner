using AlgoRunner.Api.Dal.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRunner.Api.Dal.EF
{
    public class AlgoRunnerDbContext : DbContext
    {
        public AlgoRunnerDbContext(DbContextOptions<AlgoRunnerDbContext> options) : base(options)
        {            
            //InitDB();
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<AdminInfo> AdminInfos { get; set; }
        public DbSet<AlgoDotesResult> AlgoDotesResults { get; set; }
        public DbSet<AlgoExecutionParam> AlgoExecutionParams { get; set; }
        public DbSet<AlgoParam> AlgoParams { get; set; }
        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<AlgoTableResult> AlgoTableResults { get; set; }
        public DbSet<AlgoTextResult> AlgoTextResults { get; set; }
        public DbSet<AlgResultType> AlgResultTypes { get; set; }
        //public DbSet<DashboardInfo> DashboardInfos { get; set; }
        public DbSet<ExecutionInfo> ExecutionInfos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAlgo> ProjectAlgos { get; set; }
        public DbSet<ProjectAlgoList> ProjectAlgoLists { get; set; }
        public DbSet<ProjectExecution> ProjectExecutions { get; set; }
        public DbSet<ResultCategory> ResultCategories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        
        private void InitDB()
        {
            if (!AlgResultTypes.Any())
            {
                Add(new AlgResultType { Name = "Text" });
                Add(new AlgResultType { Name = "Table" });
                Add(new AlgResultType { Name = "Lines Graph" });
                Add(new AlgResultType { Name = "Pie Graph" });
                Add(new AlgResultType { Name = "Bars Graph" });
                Add(new AlgResultType { Name = "Dotes Graph" });
                SaveChanges();
            }

            if (!Activities.Any())
            {
                Add(new Activity { Name = "Common", ServerPath = @"C:\\AlgoRunnerProjects\Common" });
                Add(new Activity { Name = "Big company project", ServerPath = @"C:\\AlgoRunnerProjects\Bp" });
                Add(new Activity { Name = "Small company project", ServerPath = @"C:\\AlgoRunnerProjects\Sp" });
                Add(new Activity { Name = "Restricted project", ServerPath = @"C:\Users\admin" });
                SaveChanges();
            }
            

            if (!Users.Any())
            {
                Add(new User { Name = "User 10", IsAdmin = false, Activities = new List<Activity> { Activities.First() } });
                Add(new User { Name = "User 12", IsAdmin = false, Activities = new List<Activity> { Activities.Last() } });
                Add(new User { Name = "User 14", IsAdmin = true, Activities = new List<Activity> { Activities.First(), Activities.Last() } });
                Add(new User { Name = @"RF\OLEGBR", IsAdmin = true, Activities = new List<Activity> { Activities.Last() } });
                SaveChanges();
            }

            if (!Messages.Any())
            {
                Add(new Message
                {
                    UserName = @"DESKTOP-KM9M96J\Oleg",
                    Context = @"This is probably the last (at least for now) of my posts about push notifications. I've updated the demo project with support for features described here (and there is still couple things on the issues list to come in future).",
                    CreateDate = new DateTime(2018, 10, 1),
                    Title = "Post1",
                    isReaded = true
                });

                Add(new Message
                {
                    UserName = @"DESKTOP-KM9M96J\Boris",
                    isReaded = false,
                    Context = @"This is probably the last (at least for now) of my posts about push notifications. I've updated the demo project with support for features described here (and there is still couple things on the issues list to come in future).",
                    CreateDate = new DateTime(2018, 10, 2),
                    Title = "Post 2"
                });
                Add(new Message
                {
                    UserName = @"DESKTOP-KM9M96J\Boris",
                    isReaded = true,
                    Context = @"This is probably the last (at least for now) of my posts about push notifications. I've updated the demo project with support for features described here (and there is still couple things on the issues list to come in future).",
                    CreateDate = new DateTime(2018, 10, 3),
                    Title = "Post 3"
                });
                SaveChanges();
            }

            if (!Algorithms.Any())
            {
                Add(new Algorithm
                {
                    Name = "Text Alg",
                    CreatedBy = "developer a1",
                    Desc = "Text Alg",
                    Activity = Activities.First(),
                    ResultType = AlgResultTypes.First(x => x.Id == 1),
                    FileServerPath = @"C:\AlgoRunnerProjects\Bp\cacbb170-b2e1-4594-b46d-c2f439a3a5a4.py",
                    AlgoParams = new List<AlgoParam>
                    {
                        new AlgoParam { Name="TimeOut", Type = new KeyValuePair<int, string>(1, "Number"), Range = new List<string>()},
                        new AlgoParam { Name="DemoStr", Type = new KeyValuePair<int, string>(2, "Text"), },
                        new AlgoParam { Name="Demo Boll", Type = new KeyValuePair<int, string>(3, "Boolean"), },
                        new AlgoParam { Name="Demo Enum", Type = new KeyValuePair<int, string>(4, "Enum"), Range=new List<string>{ "First", "Second", "Third" } },
                    }
                });

                Add(new Algorithm
                {
                    Name = "Table Alg",
                    CreatedBy = "developer a1",
                    Desc = "1 Alg.............end",
                    Activity = Activities.First(),
                    ResultType = AlgResultTypes.First(x => x.Id == 2),
                    FileServerPath = @"C:\AlgoRunnerProjects\Bp\6792778d-221d-4e81-8c36-b00ee12416a1.py",
                    AlgoParams = new List<AlgoParam>
                    {
                        new AlgoParam { Name="Num of rows", Type = new KeyValuePair<int, string>(1, "Number"), Range = new List<string>()},
                    }
                });

                Add(new Algorithm
                {
                    Name = "Alg 2",
                    CreatedBy = "user a1",
                    Desc = "2 Alg.............end",
                    Activity = Activities.First(),
                    FileServerPath = @"C:\AlgoRunnerProjects\Bp\9b-9e41f2ecf398.bat",
                    ResultType = AlgResultTypes.First(x => x.Id == 2),
                });

                Add(new Algorithm
                {
                    Name = "Alg 3",
                    CreatedBy = "user a1",
                    FileServerPath = @"C:\Users\admin\1111.bat",
                    Desc = "3 Alg.............end",
                    Activity = Activities.First(x => x.Id == 3),
                    ResultType = AlgResultTypes.First(x => x.Id == 4)
                });

                Add(new Algorithm
                {
                    Name = "Scatter Alg",
                    CreatedBy = "developer a1",
                    Desc = "1 Alg.............end",
                    Activity = Activities.First(),
                    ResultType = AlgResultTypes.First(x => x.Id == 6),
                    FileServerPath = @"C:\AlgoRunnerProjects\Bp\6792778d-221d-4e81-8c36-b00ee12416a1.py",
                    AlgoParams = new List<AlgoParam>
                    {
                        new AlgoParam { Name="Num of molec", Type = new KeyValuePair<int, string>(1, "Number"), Range = new List<string>()},
                    }
                });

                Add(new Algorithm
                {
                    Name = "Alg 5",
                    CreatedBy = "user a1",
                    Desc = "2 Alg.............end",
                    Activity = Activities.Last(),
                    ResultType = AlgResultTypes.First(x => x.Id == 3)
                });

                Add(new Algorithm
                {
                    Name = "Alg 6",
                    CreatedBy = "user a1",
                    Desc = "3 Alg.............end",
                    Activity = Activities.Last(),
                    ResultType = AlgResultTypes.First(x => x.Id == 4)
                });
                Add(new Algorithm
                {
                    Name = "Alg 7",
                    CreatedBy = "user a1",
                    Desc = "1 Alg.............end",
                    Activity = Activities.Last(),
                    ResultType = AlgResultTypes.First(x => x.Id == 6)
                });
                Add(new Algorithm
                {
                    Name = "Alg 8 common",
                    CreatedBy = "user a1",
                    Desc = "2 Alg.............end",
                    Activity = Activities.Last(),
                    ResultType = AlgResultTypes.First(x => x.Id == 5)
                });
                Add(new Algorithm
                {
                    Name = "Alg 9 common",
                    CreatedBy = "user a1",
                    Desc = "3 Alg.............end",
                    Activity = Activities.Last(),
                    ResultType = AlgResultTypes.First(x => x.Id == 1)
                });
                Add(new Algorithm
                {
                    Name = "Alg 8 common",
                    CreatedBy = "user a1",
                    Desc = "2 Alg.............end",
                    Activity = Activities.Last(),
                    ResultType = AlgResultTypes.First(x => x.Id == 2)
                });
                Add(new Algorithm
                {
                    Name = "Alg 9 common",
                    CreatedBy = "user a1",
                    Desc = "3 Alg.............end",
                    Activity = Activities.Last(),
                    ResultType = AlgResultTypes.First(x => x.Id == 1)
                });
                Add(new Algorithm
                {
                    Name = "Alg 8 common",
                    CreatedBy = "user a1",
                    Desc = "2 Alg.............end",
                    Activity = Activities.Last(),
                    ResultType = AlgResultTypes.First(x => x.Id == 4)
                });
                Add(new Algorithm
                {
                    Name = "Alg 9 common",
                    CreatedBy = "user a1",
                    Desc = "3 Alg.............end",
                    Activity = Activities.Last(),
                    ResultType = AlgResultTypes.First(x => x.Id == 2)
                });
                Add(new Algorithm
                {
                    Name = "Alg 8 common",
                    CreatedBy = "user a1",
                    Desc = "2 Alg.............end",
                    Activity = Activities.Last(),
                    ResultType = AlgResultTypes.First(x => x.Id == 6)
                });
                Add(new Algorithm
                {
                    Name = "Alg 9 common",
                    CreatedBy = "user a1",
                    Desc = "3 Alg.............end",
                    Activity = Activities.Last(),
                    ResultType = AlgResultTypes.First(x => x.Id == 1)
                });
                Add(new Algorithm
                {
                    Name = "Alg 8 common",
                    CreatedBy = "user a1",
                    Desc = "2 Alg.............end",
                    Activity = Activities.First(),
                    ResultType = AlgResultTypes.First(x => x.Id == 3)
                });
                Add(new Algorithm
                {
                    Name = "Alg 9 common",
                    CreatedBy = "user a1",
                    Desc = "3 Alg.............end",
                    Activity = Activities.First(),
                    ResultType = AlgResultTypes.First(x => x.Id == 5)
                });
                SaveChanges();
            }

            if (!Projects.Any())
            {
                Add(new Project { Name = "Project 1", LastExecutionDate = new DateTime(2018, 1, 1), IsFavorite = false, Activity = Activities.First() });
                Add(new Project { Name = "Project 2", LastExecutionDate = new DateTime(2018, 1, 1), IsFavorite = false, Activity = Activities.First() });
                Add(new Project { Name = "Project 3", LastExecutionDate = new DateTime(2018, 1, 1), IsFavorite = false, Activity = Activities.First() });
                Add(new Project { Name = "Project 4", LastExecutionDate = new DateTime(2018, 1, 1), IsFavorite = true, Activity = Activities.First() });
                Add(new Project { Name = "Project 5", LastExecutionDate = new DateTime(2018, 1, 1), IsFavorite = false, Activity = Activities.Last() });
                Add(new Project { Name = "Project 6", LastExecutionDate = new DateTime(2018, 1, 1), IsFavorite = true, Activity = Activities.First() });
                Add(new Project { Name = "Project 7", LastExecutionDate = new DateTime(2018, 1, 1), IsFavorite = false, Activity = Activities.First() });
                Add(new Project { Name = "Project 8", LastExecutionDate = new DateTime(2018, 1, 1), IsFavorite = false, Activity = Activities.Last() });
                Add(new Project
                {
                    Name = "Project 9",
                    LastExecutionDate = new DateTime(2018, 1, 1),
                    IsFavorite = true,
                    CreatedBy = "Big baga boss",
                    Desc = "Text start ...............................................................................................................................end",
                    AlgorithmsList = new List<Algorithm>
                    {
                        Algorithms.First(),
                        Algorithms.Last()                    
                    },
                    Activity = Activities.First(),
                    ExecutionsList = new List<ExecutionInfo>
                    {
                        new ExecutionInfo { ExecutedBy = "User 55", StartDate = new DateTime(2018, 10, 1, 10, 0, 0), EndDate = new DateTime(2018, 10, 1, 21, 0, 0) },
                        new ExecutionInfo { ExecutedBy = "User 1", StartDate = new DateTime(2018, 11, 1, 10, 0, 0), EndDate = new DateTime(2018, 12, 1, 21, 0, 0) }
                    }
                });
                Add(new Project
                {
                    Name = "Project 10",
                    LastExecutionDate = new DateTime(2018, 1, 1),
                    IsFavorite = false,
                    Activity = Activities.Last(),
                    ExecutionsList = new List<ExecutionInfo>
                    {
                        new ExecutionInfo { ExecutedBy = "User 1", StartDate = new DateTime(2018, 12, 1, 10, 0, 0), EndDate = new DateTime(2018, 12, 1, 21, 0, 0) },
                        new ExecutionInfo { ExecutedBy = "User 2", StartDate = new DateTime(2018, 12, 11, 10, 0, 0), EndDate = new DateTime(2018, 12, 15, 21, 0, 0) }
                    }
                });
                Add(new Project
                {
                    Name = "Project 11",
                    LastExecutionDate = new DateTime(2018, 1, 1),
                    IsFavorite = false,
                    Activity = Activities.First(),
                    ExecutionsList = new List<ExecutionInfo>
                    {
                        new ExecutionInfo { ExecutedBy = "User 2", StartDate = new DateTime(2018, 12, 12, 10, 0, 0), EndDate = new DateTime(2018, 12, 17, 21, 0, 0) }
                    }
                });
                Add(new Project { Name = "Project 12", LastExecutionDate = new DateTime(2018, 1, 1), IsFavorite = false, Activity = Activities.Last() });
                Add(new Project { Name = "Project 13", LastExecutionDate = new DateTime(2018, 1, 1), IsFavorite = false, Activity = Activities.Last() });
                Add(new Project { Name = "Project 14", LastExecutionDate = new DateTime(2018, 1, 3), IsFavorite = false, Activity = Activities.Last() });
                Add(new Project { Name = "Project 15", LastExecutionDate = new DateTime(2018, 1, 4), IsFavorite = false, Activity = Activities.First() });
                Add(new Project { Name = "Project 16", LastExecutionDate = new DateTime(2018, 1, 5), IsFavorite = false, Activity = Activities.First() });
                Add(new Project { Name = "Project 17", LastExecutionDate = new DateTime(2018, 1, 6), IsFavorite = true, Activity = Activities.Last() });
                Add(new Project { Name = "Project 18", LastExecutionDate = new DateTime(2018, 1, 7), IsFavorite = false, Activity = Activities.Last() });
                Add(new Project { Name = "Project 19", LastExecutionDate = new DateTime(2018, 1, 10), IsFavorite = false, Activity = Activities.First() });
                SaveChanges();
            }
        }
    }
}
