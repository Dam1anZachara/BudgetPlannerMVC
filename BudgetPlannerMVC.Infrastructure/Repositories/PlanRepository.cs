using BudgetPlannerMVC.Domain.Interfaces;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Infrastructure.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly Context _context;
        public PlanRepository(Context context)
        {
            _context = context;
        }
        public int AddPlan(Plan plan)
        {
            _context.Plans.Add(plan);
            _context.SaveChanges();
            return plan.Id;
        }
        public void DeletePlan(int id)
        {
            var plan = _context.Plans.Find(id);
            _context.Plans.Remove(plan);
            _context.SaveChanges();
        }
        public IQueryable<Plan> GetAllPlans()
        {
            return _context.Plans;
        }
        public Plan GetPlan(int id)
        {
            return _context.Plans.FirstOrDefault(p => p.Id == id);
        }
        public void UpdatePlan(Plan plan)
        {
            _context.Attach(plan);
            _context.Entry(plan).Property("Name").IsModified = true;
            _context.Entry(plan).Property("IsActive").IsModified = true;
            _context.Entry(plan).Property("DateStart").IsModified = true;
            _context.Entry(plan).Property("DateEnd").IsModified = true;
            _context.SaveChanges();
        }
    }
}
