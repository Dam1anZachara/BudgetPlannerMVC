using BudgetPlannerMVC.Application.ViewModels.PlanView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Interfaces
{
    public interface IPlanTypeService
    {
        int AddPlanType(NewPlanTypeVm planType);
        void DeletePlanType(int id);
        ListPlanTypesForListVm GetAllPlanTypesForList(int pageSize, int pageNo, string searchString, int planId);
        NewPlanTypeVm GetPlanTypeForEdit(int id);
        void UpdatePlanType(NewPlanTypeVm model);
        List<string> DropDownTypesForPlan(int id);
    }
}
