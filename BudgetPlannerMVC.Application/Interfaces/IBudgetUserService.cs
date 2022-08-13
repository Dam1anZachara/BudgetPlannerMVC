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
        int AddBudgetUserAfterEmailConfirm(string userId, string userName, string mainMail);
        int AddAddressForBudgetUserAfterEmailConfirm(int budgetUserId);
        int CountContactDetailsForAddBudgetUser(NewBudgetUserVm budgetUser, string addContact, string removeContact);
        void DeleteBudgetUser(int id);
        void DeleteBudgetUserAfterDeletePersonalData(string userId);
        IQueryable<BudgetUserVm> DropDownBudgetUsers();
        ListBudgetUserForListVm GetAllBudgetUsersForList(int pageSize, int pageNo, string searchString);
        NewBudgetUserVm GetBudgetUserForEdit(int id);
        void UpdateBudgetUser(NewBudgetUserVm model);
        IQueryable<ContactDetailTypeVm> DropDownContactDetailTypes();
        NewBudgetUserVm GetBudgetUserForCreateProfile(string id);
        int GetBudgetUserIdLoggedIn(string userId);
    }
}
