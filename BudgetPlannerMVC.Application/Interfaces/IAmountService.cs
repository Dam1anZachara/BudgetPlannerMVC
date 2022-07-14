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
        int AddAmount(NewAmountVm amount);
        void DeleteAmount(int id);
        List<AmountForListVm> GetFiltredAmountsForList(FilterForAmountForListAmount filterForAmount, DateSelectForListAmountVm dateSelect);
        TypeAndUserSelectedForListAmount SelectedUserNameForListAmount(FilterForAmountForListAmount filterForAmount);
        SumValuesForListAmountVm GetSumValuesForListAmount(List<AmountForListVm> amounts);
        ListAmountForListVm GetAllAmountsForList(int pageSize, int pageNo, SumValuesForListAmountVm sumValues, TypeAndUserSelectedForListAmount typeUserName, List<AmountForListVm> amounts, DateSelectForListAmountVm dateSelect);
        NewAmountVm GetAmountForEdit(int id);
        void UpdateAmount(NewAmountVm amount);
        DateSelectForListAmountVm GetDateSelect(DateTime startDate, DateTime endDate);
    }
}
