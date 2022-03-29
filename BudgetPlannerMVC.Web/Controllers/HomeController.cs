using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService _itemService;

        public HomeController(ILogger<HomeController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            _itemService.GetAllItems();
            return View();
        }
        public IActionResult ConfigureYourBudget()
        {
            List<AmountType> amountTypes = new List<AmountType>();
            return View();
        }
        public IActionResult ViewListOfItems()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { Id = 1, Name = "Apple", TypeName = "Grocery" });
            items.Add(new Item() { Id = 2, Name = "Strawberry", TypeName = "Grocery" });
            items.Add(new Item() { Id = 3, Name = "Pineapple", TypeName = "Grocery" });

            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
