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
        int DeletePlanType(int id);
        IQueryable<PlanType> GetAllPlanTypes();
        void UpdatePlanType(PlanType planType);
    }
}
