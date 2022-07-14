using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using BudgetPlannerMVC.Application.ViewModels.UserView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Interfaces
{
    public interface IBudgetUserService
    {
        int AddBudgetUser(NewBudgetUserVm budgetUser);
        public int AddAddressForBudgetUser(NewBudgetUserVm budgetUser, int budgetUserId);
        void AddContactDetailsForBudgetUserAdd(NewBudgetUserVm budgetUser, int budgetUserId);
        int CountContactDetailsForAddBudgetUser(NewBudgetUserVm budgetUser, string addContact, string removeContact);
        void DeleteBudgetUser(int id);
        IQueryable<BudgetUserVm> DropDownBudgetUsers();
        ListBudgetUserForListVm GetAllBudgetUsersForList(int pageSize, int pageNo, string searchString);
        NewBudgetUserVm GetBudgetUserForEdit(int id);
        void UpdateBudgetUser(NewBudgetUserVm model);
        void UpdateAdressForBudgetUser(NewBudgetUserVm model);
        void AddDeleteUpdateContactDetailsForBudgetUserEdit(NewBudgetUserVm model);
        IQueryable<ContactDetailTypeVm> DropDownContactDetailTypes();

    }
}
