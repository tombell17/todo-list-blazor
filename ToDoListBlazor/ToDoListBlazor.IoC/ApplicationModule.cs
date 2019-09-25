using Microsoft.Extensions.DependencyInjection;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Infrastructure.Repositories;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.IoC
{
    public class ApplicationModule
    {
        public static void BindApplicationModules(IServiceCollection services)
        {
            //services.AddSingleton<IToDoRepository, ToDoInMemoryRepository>();
            services.AddTransient<IRepository<ToDo>, EFRepository<ToDo>>();
        }
    }
}
