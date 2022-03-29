using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Web.Models
{
    public class AmountType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeOfAmount Type { get; set; }
    }
    public enum TypeOfAmount
    {
        Expense,
        Income
    }
}
