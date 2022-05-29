using BudgetPlannerMVC.Domain.Interfaces;
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
    }
}
