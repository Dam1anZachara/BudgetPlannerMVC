using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.AmountView
{
    public class SumValuesForListAmountVm
    {
        [DataType(DataType.Currency, ErrorMessage = "...")]
        public decimal SumOfExpenses { get; set; }
        [DataType(DataType.Currency, ErrorMessage = "...")]
        public decimal SumOfIncomes { get; set; }
        [DataType(DataType.Currency, ErrorMessage = "...")]
        public decimal Balance { get; set; }
    }
}
