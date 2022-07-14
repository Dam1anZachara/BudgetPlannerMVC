using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.AmountView
{
    public class ListAmountForListVm
    {
        public List<AmountForListVm> Amounts { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
        public TypeAndUserSelectedForListAmount TypeUserName { get; set; }
        public DateSelectForListAmountVm DateSelect { get; set; }
        public SumValuesForListAmountVm SumValues { get; set; }
        public FilterForAmountForListAmount FilterForAmount { get; set; }
    }
}
