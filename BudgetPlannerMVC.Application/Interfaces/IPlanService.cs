using BudgetPlannerMVC.Application.ViewModels.PlanView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Interfaces
{
    public interface IPlanService
    {
        int AddPlan(NewPlanVm plan);
        void DeletePlan(int id);
        ListPlanForListVm GetAllPlansForList(int pageSize, int pageNo, string searchString);
        NewPlanVm GetPlanForEdit(int id);
        void UpdatePlan(NewPlanVm model);
        void UpdateListOfPlans(ListPlanForListVm plans);
        ListPlanForListVm StatusPlan(int id);
    }
}
