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
        public int AddAmount(Amount amount)
        {
            _context.Amounts.Add(amount);
            _context.SaveChanges();
            return amount.Id;
        }
        public void DeleteAmount(int id)
        {
            var amount = _context.Amounts.Find(id);
            _context.Amounts.Remove(amount);
            _context.SaveChanges();
        }
        public IQueryable<Amount> GetAllAmounts()
        {
            return _context.Amounts;
        }
        public void ChangeBudgetUserInAmountOnDelete(int id)
        {
            var amounts = _context.Amounts.Where(p => p.BudgetUserId == id).ToList();
            foreach (var amount in amounts)
            {
                amount.BudgetUserId = 1;
                _context.SaveChanges();
            }
        }
        public void UpdateAmount(Amount amount)
        {
            _context.Attach(amount);
            _context.Entry(amount).Property("Date").IsModified = true;
            _context.Entry(amount).Property("Value").IsModified = true;
            _context.Entry(amount).Property("Description").IsModified = true;
            _context.Entry(amount).Property("TypeId").IsModified = true;
            _context.Entry(amount).Property("BudgetUserId").IsModified = true;
            _context.SaveChanges();
        }
    }
}
