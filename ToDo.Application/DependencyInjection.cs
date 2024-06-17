using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Interfaces;
using ToDo.Application.Services;
using ToDo.Domain.Interfaces;
using ToDo.Infraestructure.Repositories;

namespace ToDo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
