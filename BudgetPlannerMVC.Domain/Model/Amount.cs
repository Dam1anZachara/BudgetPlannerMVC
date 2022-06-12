using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Model
{
    public class Amount
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public int? BudgetUserId { get; set; }

        public virtual Type Type { get; set; }
        public virtual BudgetUser BudgetUser { get; set; }
    }
}
