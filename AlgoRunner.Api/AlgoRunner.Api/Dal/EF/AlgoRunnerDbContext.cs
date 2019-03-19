using AlgoRunner.Api.Dal.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AlgoRunner.Api.Dal.EF
{
    public class AlgoRunnerDbContext : DbContext
    {
        private static bool _isFirstTime = true;

        public AlgoRunnerDbContext(DbContextOptions<AlgoRunnerDbContext> options) : base(options)
        {
            //if (_isFirstTime)
            //{
            //    _isFirstTime = false;
            //    InitDB();
            //}
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<AlgoExecutionParam> AlgoExecutionParams { get; set; }
        public DbSet<AlgoParam> AlgoParams { get; set; }
        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<AlgResultType> AlgResultTypes { get; set; }
        public DbSet<ExecutionInfo> ExecutionInfos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAlgo> ProjectAlgos { get; set; }
        public DbSet<ProjectExecution> ProjectExecutions { get; set; }
        public DbSet<UserFavoriteProject> UserFavoriteProjects { get; set; }
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
        }
    }
}
