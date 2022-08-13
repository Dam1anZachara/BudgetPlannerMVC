using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.UserView
{
    public class ListBudgetUserForListVm
    {
        public List<BudgetUserForListVm> BudgetUsers { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
        public string CurrentUserId { get; set; }
        public int CountAdminUsers { get; set; }
    }
}
