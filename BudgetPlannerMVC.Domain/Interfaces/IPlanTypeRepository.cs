using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Interfaces
{
    public interface IPlanTypeRepository
    {
        int AddPlanType(PlanType planType);
        void DeletePlanType(int id);
        IQueryable<PlanType> GetAllPlanTypes();
        PlanType GetPlanType(int id);
        void UpdatePlanType(PlanType planType);
    }
}
