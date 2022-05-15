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
        ListTypeForListVm GetAllTypesForList(int pageSize, int pageNo, string searchString);
        int AddType(NewTypeVm type);
        NewTypeVm GetTypeForEdit(int id);
        void UpdateType(NewTypeVm model);
        void DeleteType(int id);
        //NewTypeVm GetAllAssignsForList(NewTypeVm model);
        List<string> DropDownAssigns();
        int GetAssignIdByName(string nameOfAssign);
    }
}
