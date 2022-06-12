using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Model
{
    public class PlanType
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int TypeId { get; set; }
        public int PlanId { get; set; }

        public virtual Type Type { get; set; }
        public virtual Plan Plan { get; set; }
    }
}
