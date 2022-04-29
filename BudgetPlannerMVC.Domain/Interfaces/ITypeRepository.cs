using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Interfaces
{
    public interface ITypeRepository
    {
        IQueryable<Model.Type> GetAllTypes();
        IQueryable<Model.Type> GetAllExpenseTypes();
        IQueryable<Model.Type> GetAllIncomeTypes();
        Model.Type GetType(int typeId);
        int AddType(Model.Type type);
        void UpdateCustomer(Model.Type type);
        void DeleteType(int id);
    }
}
