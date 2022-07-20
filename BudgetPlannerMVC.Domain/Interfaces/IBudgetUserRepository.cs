using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Interfaces
{
    public interface IBudgetUserRepository
    {
        int AddBudgetUser(BudgetUser budgetUser);
        void DeleteBudgetUser(int id);
        public void DeleteContactDetail(int id);
        IQueryable<BudgetUser> GetAllBudgetUsers();
        BudgetUser GetBudgetUser(int id);
        IQueryable<ContactDetail> GetAllContactDetails();
        void UpdateBudgetUser(BudgetUser budgetUser);
        IQueryable<ContactDetailType> GetAllContactDetailTypes();
        int AddAddres(Address address);
        void UpdateAddressForBudgetUser(Address address);
        int AddContactDetail(ContactDetail contactDetail);
    }
}
