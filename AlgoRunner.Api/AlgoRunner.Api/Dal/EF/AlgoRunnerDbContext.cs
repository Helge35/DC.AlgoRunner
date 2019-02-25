using AlgoRunner.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlgoRunner.Api.Dal.EF
{
    public class AlgoRunnerDbContext : DbContext
    {
        public AlgoRunnerDbContext(DbContextOptions<AlgoRunnerDbContext> options)
           : base(options)
        { }

        public DbSet<PointTest> Points { get; set; }
    }

    public class AlgoRunnerDbContextFactory : IDesignTimeDbContextFactory<AlgoRunnerDbContext>
    {
        IConfiguration Configuration { get; }
        public AlgoRunnerDbContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public AlgoRunnerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AlgoRunnerDbContext>();
            builder.UseSqlServer(Configuration["ConnectionStrings:AlgoRunnerConnectionString"]);
            return new AlgoRunnerDbContext(builder.Options);
        }
    }

    public class PointTest
    {
        [Key]
        public int ID { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}
