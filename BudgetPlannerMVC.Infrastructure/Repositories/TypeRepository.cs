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
        private readonly Context _context;
        public TypeRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<Domain.Model.Type> GetAllTypes()
        {
            return _context.Types;
        }
        public IQueryable<Domain.Model.Type> GetAllExpenseTypes()
        {
            return _context.Types.Where(p => p.AssignId == 1);
        }

        public Domain.Model.Type GetType(int typeId)
        {
            throw new NotImplementedException();
        }
    }
}
