using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ITypeService, TypeService>();
            services.AddTransient<IAmountService, AmountService>(); 
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
