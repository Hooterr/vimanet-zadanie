using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using vimanet.DataAccess;
using vimanet.DataAccess.Entities;

namespace vimanet
{
    public class Startup
    {
        // A trick to make in-memory db persistent
        // When there aren't any open connections db gets deleted this variable stores an open connection
        private SqliteConnection inMemorySqlite;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson();

            inMemorySqlite = new SqliteConnection("Data Source=:memory:");
            inMemorySqlite.Open();
            
            services.AddDbContext<AppDataContext>(options =>
            {
                options.UseSqlite(inMemorySqlite);
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            DataAccessInstaller.Install(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDataContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            dbContext.Database.EnsureCreated();
            dbContext.Users.AddRange(new List<User>()
            {
                new User
                {
                    FirstName = "Krystian",
                    LastName = "Nowak"
                },
                new User
                {
                    FirstName = "Maciej",
                    LastName = "Kowalski"
                },
                new User
                {
                    FirstName = "Zbigniew",
                    LastName = "Czajka"
                }
            });

            dbContext.Groups.AddRange(new List<TaskGroup>()
            {
                new TaskGroup()
                {
                    Name = "Jeden",
                    UserTasks = new List<UserTask>()
                    {
                        new UserTask()
                        {
                            Name = "Task numero 1",
                            Deadline = new System.DateTime(2020, 5, 12),
                            Status = TaskStatus.InProgress,
                        }
                    }

                },
                new TaskGroup()
                {
                    Name = "Dwa"
                },
                new TaskGroup()
                {
                    Name = "Trzy"
                },
                new TaskGroup()
                {
                    Name = "Cztery"
                },
            }) ;
            dbContext.SaveChanges();
        }
    }
}
