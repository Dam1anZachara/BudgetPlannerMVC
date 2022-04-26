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
        Model.Type GetType(int typeId);
    }
}
