using BudgetPlannerMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Infrastructure.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        public IQueryable<Domain.Model.Type> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public Domain.Model.Type GetType(int typeId)
        {
            throw new NotImplementedException();
        }
    }
}
