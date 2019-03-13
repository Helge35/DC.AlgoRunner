using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Dal.EF;
using AlgoRunner.Api.Hubs;
using AlgoRunner.Api.Services;
using AutoMapper;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlgoRunner.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddCors();
            services.AddAutoMapper();
            services.AddMvc();

            //GlobalConfiguration.Configuration.UseSqlServerStorage("<connection string or its name>");

            var connection = Configuration["ConnectionStrings:AlgoRunnerConnectionString"];
            services.AddDbContext<AlgoRunnerDbContext>
                (options => options.UseSqlServer(connection));

            services.AddSignalR();
            services.AddAuthentication(Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ProjectsRepository>();
            services.AddScoped<ProjectsRepository>();
            services.AddSingleton<UsersRepository>();
            services.AddScoped<UsersRepository>();
            services.AddSingleton<ActivityRepository>();
            services.AddScoped<ActivityRepository>();
            services.AddSingleton<MessagesRepository>();
            services.AddScoped<MessagesRepository>();

            services.AddScoped<AlgoExecutionService>();//must be NOT singletone
            services.AddSingleton<FilesService>();


            services.AddHangfire(x => { x.UseMemoryStorage(); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(x => x
               // .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:4200")
                .AllowCredentials());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSignalR(routes =>
            {
                routes.MapHub<MessageHub>("/hubs/message");
                routes.MapHub<ExecutionHab>("/hubs/execution");
            });

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
