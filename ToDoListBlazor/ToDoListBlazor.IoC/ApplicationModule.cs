using Microsoft.Extensions.DependencyInjection;
using ToDoListBlazor.Application.Mappers;
using ToDoListBlazor.Application.Services;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Entities;
using ToDoListBlazor.Infrastructure.Repositories;

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

            #region Mappers
            services.AddTransient<IUserMapper, UserMapper>();
            services.AddTransient<IToDoMapper, ToDoMapper>();
            #endregion

            #region Services
            services.AddTransient<IUserAccountService, UserAccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IToDoService, ToDoService>();
            #endregion
        }
    }
}
