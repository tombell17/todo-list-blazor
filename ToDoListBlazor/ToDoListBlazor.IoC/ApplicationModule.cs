using Microsoft.Extensions.DependencyInjection;
using ToDoListBlazor.Domain;
using ToDoListBlazor.Infrastructure;

namespace ToDoListBlazor.IoC
{
    public class ApplicationModule
    {
        public static void BindApplicationModules(IServiceCollection services)
        {
            services.AddSingleton<IToDoRepository, ToDoRepository>();
        }
    }
}
