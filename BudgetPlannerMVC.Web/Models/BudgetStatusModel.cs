using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Web.Models
{
    public class BudgetStatusModel
    {
        public List<AmountModel> Expenses { get; set; }
        public List<AmountModel> Incomes { get; set; }
    }
}
