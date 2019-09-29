using Microsoft.Extensions.DependencyInjection;
using ToDoListBlazor.Application.Services;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Shared;
using ToDoListBlazor.Infrastructure.Abstractions;
using ToDoListBlazor.Infrastructure.Repositories;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.IoC
{
    public class ApplicationModule
    {
        public static void BindApplicationModules(IServiceCollection services)
        {
            #region Repositories
            services.AddTransient<IRepository<ToDo>, EFRepository<ToDo>>();
            services.AddTransient<IRepository<User>, EFRepository<User>>();
            #endregion

            services.AddTransient<IUserMapper, UserMapper>();
            services.AddTransient<IUserAccountService, UserAccountService>(); 
            
        }
    }
}
