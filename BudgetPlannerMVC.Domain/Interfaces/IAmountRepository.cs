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
        Amount GetAmount(int amountId); // nie używane
        int AddAmount(Amount amount);
        void UpdateAmount(Amount amount);
        void DeleteAmount(int id);
        IQueryable<Domain.Model.Type> GetTypes();
    }
}
