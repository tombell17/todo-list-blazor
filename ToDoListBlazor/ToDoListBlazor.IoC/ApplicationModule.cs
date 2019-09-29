﻿using Microsoft.Extensions.DependencyInjection;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Infrastructure.Abstractions;
using ToDoListBlazor.Infrastructure.Repositories;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.IoC
{
    public class ApplicationModule
    {
        public static void BindApplicationModules(IServiceCollection services)
        {            
            services.AddTransient<IRepository<ToDo>, EFRepository<ToDo>>();
            services.AddTransient<IUserMapper, UserMapper>();
        }
    }
}
