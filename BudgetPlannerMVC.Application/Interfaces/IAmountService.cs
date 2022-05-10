using BudgetPlannerMVC.Application.ViewModels.AmountView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Interfaces
{
    public interface IAmountService
    {
        ListAmountForListVm GetAllAmountsForList(int pageSize, int pageNo, string searchString);
        int AddAmount(NewAmountVm amount);
        List<string> DropDownTypes();
        int GetTypeIdByName(string nameOfType);
        NewAmountVm GetAmountForEdit(int id);
        void UpdateAmount(NewAmountVm amount);
    }
}
