using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.Services;
using BudgetPlannerMVC.Application.ViewModels.AmountView;
using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static BudgetPlannerMVC.Application.ViewModels.AmountView.NewAmountVm;
using static BudgetPlannerMVC.Application.ViewModels.BudgetUserView.AddressVm;
using static BudgetPlannerMVC.Application.ViewModels.BudgetUserView.ContactDetailVm;
using static BudgetPlannerMVC.Application.ViewModels.BudgetUserView.NewBudgetUserVm;
using static BudgetPlannerMVC.Application.ViewModels.PlanView.NewPlanTypeVm;
using static BudgetPlannerMVC.Application.ViewModels.PlanView.NewPlanVm;

namespace BudgetPlannerMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ITypeService, TypeService>();
            services.AddTransient<IAmountService, AmountService>();
            services.AddTransient<IPlanService, PlanService>();
            services.AddTransient<IPlanTypeService, PlanTypeService>();
            services.AddTransient<IBudgetStatusService, BudgetStatusService>();
            services.AddTransient<IBudgetUserService, BudgetUserService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IValidator<NewAmountVm>, NewAmountValidation>();
            services.AddTransient<IValidator<NewTypeVm>, NewTypeValidation>();
            services.AddTransient<IValidator<NewPlanVm>, NewPlanValidation>();
            services.AddTransient<IValidator<NewPlanTypeVm>, NewPlanTypeValidation>();
            services.AddTransient<IValidator<NewBudgetUserVm>, NewBudgetUserValidation>();
            services.AddTransient<IValidator<ContactDetailVm>, NewContactDetailValidation>();
            services.AddTransient<IValidator<AddressVm>, NewAddressValidation>();
            return services;
        }
    }
}
