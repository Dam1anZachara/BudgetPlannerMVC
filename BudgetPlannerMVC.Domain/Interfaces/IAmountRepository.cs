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
        void DeleteAmount(int amountId);

        int AddAmount(Amount amount);
            
        IQueryable<Amount> GetAmountsByTypeId(int typeId);

        Amount GetAmountById(int amountId);

        void DeleteType(int typeId);

        int AddType(Domain.Model.Type type);

        IQueryable<Domain.Model.Type> GetTypeByAssignId(int assignId);

        public Domain.Model.Type GetTypeById(int typeId);
    }
}
