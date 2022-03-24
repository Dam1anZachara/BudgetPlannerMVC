using BudgetPlannerMVC.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Services
{
    public class ItemService : IItemService
    {
        //public ItemService(IItemRepository itemRepository)
        //{

        //}
        public List<int> GetAllItems()
        {
            return new List<int>();
        }
    }
}
