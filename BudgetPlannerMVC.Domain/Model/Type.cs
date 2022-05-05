using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Model
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignId { get; set; }

        public virtual ICollection<Amount> Amounts { get; set; }
        public virtual Assign Assign { get; set; }
    }
}
