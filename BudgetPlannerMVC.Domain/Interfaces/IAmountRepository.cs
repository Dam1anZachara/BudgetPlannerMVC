using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Interfaces
{
    public interface IAmountRepository
    {
        IQueryable<Amount> GetAllAmounts();
        int AddAmount(Amount amount);
        void UpdateAmount(Amount amount);
        void DeleteAmount(int id);
        public void ChangeBudgetUserInAmountOnDelete(int id);
    }
}
