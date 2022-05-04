using BudgetPlannerMVC.Domain.Interfaces;
using BudgetPlannerMVC.Domain.Model;
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
            return _context.Types.OrderBy(p => p.AssignId);
        }
        public Domain.Model.Type GetType(int typeId)
        {
            return _context.Types.FirstOrDefault(p => p.Id == typeId);
        }

        public int AddType(Domain.Model.Type type)
        {
            _context.Types.Add(type);
            _context.SaveChanges();
            return type.Id;
        }

        public void UpdateCustomer(Domain.Model.Type type)
        {
            _context.Attach(type);
            _context.Entry(type).Property("Name").IsModified = true;
            _context.Entry(type).Property("AssignId").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteType(int id)
        {
            var type = _context.Types.Find(id);
            _context.Types.Remove(type);
            _context.SaveChanges();
        }
        public IQueryable<Assign> GetAssigns()
        {
            return _context.Assigns;
        }
    }
}
