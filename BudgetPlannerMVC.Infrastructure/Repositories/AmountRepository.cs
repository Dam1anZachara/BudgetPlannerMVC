using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Infrastructure.Repositories
{
    public class AmountRepository
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
    }
}
