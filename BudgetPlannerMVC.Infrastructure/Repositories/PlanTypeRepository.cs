using BudgetPlannerMVC.Domain.Interfaces;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Infrastructure.Repositories
{
    public class PlanTypeRepository : IPlanTypeRepository
    {
        private readonly Context _context;
        public PlanTypeRepository(Context context)
        {
            _context = context;
        }
        public int AddPlanType(PlanType planType)
        {
            _context.PlanTypes.Add(planType);
            _context.SaveChanges();
            return planType.Id;
        }
        public int DeletePlanType(int id)
        {
            var planType = _context.PlanTypes.Find(id);
            var planId = planType.PlanId;
            _context.PlanTypes.Remove(planType);
            _context.SaveChanges();
            return planId;
        }
        public IQueryable<PlanType> GetAllPlanTypes()
        {
            return _context.PlanTypes;
        }
        public void UpdatePlanType(PlanType planType)
        {
            _context.Attach(planType);
            _context.Entry(planType).Property("Value").IsModified = true;
            _context.SaveChanges();
        }
    }
}
