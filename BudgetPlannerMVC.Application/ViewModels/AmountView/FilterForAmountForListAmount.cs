using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.AmountView
{
    public class FilterForAmountForListAmount
    {
        public int SearchTypeId { get; set; }
        public IQueryable<TypeVm> Types { get; set; }
        public int SearchUserId { get; set; }
        public IQueryable<BudgetUserVm> BudgetUsers { get; set; }
    }
}
