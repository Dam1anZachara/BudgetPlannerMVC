using BudgetPlannerMVC.Domain.Interfaces;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Infrastructure.Repositories
{
    public class AmountRepository : IAmountRepository
    {
        private readonly Context _context;
        public AmountRepository(Context context)
        {
            _context = context;
        }

        public void DeleteAmount(int amountId)
        {
            var amount = _context.Amounts.Find(amountId);
            if (amount != null)
            {
                _context.Amounts.Remove(amount);
                _context.SaveChanges();
            }
        }

        public int AddAmount(Amount amount)
        {
            _context.Amounts.Add(amount);
            _context.SaveChanges();
            return amount.Id;
        }

        public IQueryable<Amount> GetAmountsByTypeId(int typeId)
        {
            var amounts = _context.Amounts.Where(a => a.TypeId == typeId);
            return amounts;
        }

        public Amount GetAmountById(int amountId)
        {
            var amount = _context.Amounts.FirstOrDefault(a => a.Id == amountId);
            return amount;
        }
        
        public void DeleteType(int typeId)
        {
            var type = _context.Types.Find(typeId);
            if (type != null)
            {
                _context.Types.Remove(type);
                _context.SaveChanges();
            }
        }
        public int AddType(Domain.Model.Type type)
        {
            _context.Types.Add(type);
            _context.SaveChanges();
            return type.Id;
        }

        public IQueryable<Domain.Model.Type> GetTypeByAssignId(int assignId)
        {
            var types = _context.Types.Where(t => t.AssignId == assignId);
            return types;
        }

        public Domain.Model.Type GetTypeById(int typeId)
        {
            var type = _context.Types.FirstOrDefault(t => t.Id == typeId);
            return type;
        }
    }
}
