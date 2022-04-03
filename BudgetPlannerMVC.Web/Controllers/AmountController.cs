using BudgetPlannerMVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class AmountController : Controller
    {
        private ConfigurationController configurationController = new ConfigurationController();
        private static IList<AmountModel> amounts = new List<AmountModel>();
        private static IList<ConfigurationModel> _configurations;

        public AmountController()
        {
            _configurations = configurationController.GetAllConfigModels();
        }

        public List<AmountModel> GetAllExpenses()
        {
            return amounts.Where(p => p.TypeOfAmount == TypeOfAmount.Expense).ToList();
        }
        public List<AmountModel> GetAllIncomes()
        {
            return amounts.Where(p => p.TypeOfAmount == TypeOfAmount.Income).ToList();
        }

        // GET: Amount
        public ActionResult Index()
        {
            return View(amounts);
        }

        // GET: Amount/Details/5
        public ActionResult Details(int id)
        {
            return View(amounts.FirstOrDefault(p => p.Id == id));
        }

        // GET: Amount/Create
        public ActionResult Create()
        {
            var configNames = new List<string>();
            foreach (var config in _configurations)
            {
                configNames.Add(config.TypeName);
            }
            ViewBag.configNames = configNames;
            return View(new AmountModel());
        }

        // POST: Amount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AmountModel amountModel)
        {
            var configuration = _configurations.FirstOrDefault(p => p.TypeName == amountModel.TypeName);
            amountModel.Id = amounts.Count+1;
            //amountModel.TypeName = configuration.TypeName;
            amountModel.TypeOfAmount = configuration.TypeOfAmount;
            amounts.Add(amountModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Amount/Edit/5
        public ActionResult Edit(int id)
        {
            return View(amounts.FirstOrDefault(p => p.Id == id));
        }

        // POST: Amount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AmountModel amountModel)
        {
            AmountModel amount = amounts.FirstOrDefault(p => p.Id == id);
            amount.Value = amountModel.Value;
            amount.Date = amountModel.Date;
            return RedirectToAction(nameof(Index));
        }

        // GET: Amount/Delete/5
        public ActionResult Delete(int id)
        {
            return View(amounts.FirstOrDefault(p => p.Id == id));
        }

        // POST: Amount/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AmountModel amountModel)
        {
            AmountModel amount = amounts.FirstOrDefault(p => p.Id == id);
            amounts.Remove(amount);
            return RedirectToAction(nameof(Index));
        }
    }
}
