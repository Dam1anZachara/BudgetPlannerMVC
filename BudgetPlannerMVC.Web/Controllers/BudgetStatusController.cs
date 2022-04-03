using BudgetPlannerMVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class BudgetStatusController : Controller
    {
        private static IList<BudgetStatusModel> budgetStatusModels;
        private BudgetStatusModel budgetStatusModel;
        private AmountController amountController = new AmountController();
        public BudgetStatusController()
        {
            budgetStatusModels = new List<BudgetStatusModel>();
            budgetStatusModel = new BudgetStatusModel()
            {
                Expenses = amountController.GetAllExpenses(),
                Incomes = amountController.GetAllIncomes()
            };
            budgetStatusModels.Add(budgetStatusModel);
        }

        // GET: BudgetBallance
        public ActionResult Index()
        { 
            return View(budgetStatusModels);
        }
    }
}
