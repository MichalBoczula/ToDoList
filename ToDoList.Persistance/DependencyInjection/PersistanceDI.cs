using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Contracts;
using ToDoList.Persistance.Context;

namespace ToDoList.Persistance.DependencyInjection
{
    public static class PersistanceDI
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddScoped<IToDoDbContext, ToDoDbContext>();
            return services;
        }
    }
}
