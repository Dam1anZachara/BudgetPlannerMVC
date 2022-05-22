﻿using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.Services;
using BudgetPlannerMVC.Application.ViewModels.AmountView;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static BudgetPlannerMVC.Application.ViewModels.AmountView.NewAmountVm;

namespace BudgetPlannerMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ITypeService, TypeService>();
            services.AddTransient<IAmountService, AmountService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IValidator<NewAmountVm>, NewAmountValidation>();
            return services;
        }
    }
}
