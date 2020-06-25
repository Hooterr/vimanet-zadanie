using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using vimanet.DataAccess.Entities;
using vimanet.DataAccess.Repositories;

namespace vimanet.DataAccess
{
    public static class DataAccessInstaller
    {
        /// <summary>
        /// Registers services from the DataAccess project
        /// </summary>
        /// <param name="services">Collection of services to bind to</param>
        public static void Install(IServiceCollection services)
        {
            services
                .AddScoped<ITaskGroupRepository, TaskGroupRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ITaskGroupRepository, TaskGroupRepository>()
                .AddScoped<IUserTaskRepository, UserTaskRepository>();
        }
    }
}
