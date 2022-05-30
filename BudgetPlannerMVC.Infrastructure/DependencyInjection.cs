using BudgetPlannerMVC.Domain.Interfaces;
using BudgetPlannerMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITypeRepository, TypeRepository>();
            services.AddTransient<IAmountRepository, AmountRepository>();   
            services.AddTransient<IPlanRepository, PlanRepository>();   
            return services;
        }
    }
}
