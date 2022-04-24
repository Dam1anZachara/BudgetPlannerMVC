using BudgetPlannerMVC.Application.ViewModels.TypeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Interfaces
{
    public interface ITypeService
    {
        ListTypeForListVm GetAllTypesForList();
        int AddType(NewTypeVm type);

        //TypeDetailsVm GetTypeDetails(int typeId);
    }
}
