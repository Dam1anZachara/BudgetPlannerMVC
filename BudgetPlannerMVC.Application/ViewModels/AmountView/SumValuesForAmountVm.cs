using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.AmountView
{
    public class SumValuesForAmountVm
    {
        public decimal SumOfExpenses { get; set; }
        public decimal SumOfIncomes { get; set; }
        public decimal Balance { get; set; }
    }
}
