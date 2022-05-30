using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Interfaces
{
    public interface IPlanRepository
    {
        public int AddPlan(Plan plan);
        public void DeletePlan(int id);
        public IQueryable<Plan> GetAllPlans();
        public Plan GetPlan(int id);
        public void UpdatePlan(Plan plan);
    }
}
