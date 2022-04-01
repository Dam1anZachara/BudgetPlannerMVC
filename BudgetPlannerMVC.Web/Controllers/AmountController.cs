using BudgetPlannerMVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class AmountController : Controller
    {
        ConfigurationController configurationController = new ConfigurationController();
        private static IList<AmountModel> amounts = new List<AmountModel>();
        private static IList<ConfigurationModel> _configurations;

        public AmountController()
        {
            _configurations = configurationController.GetAllConfigModels();
        }
        // GET: Amount
        public ActionResult Index()
        {
            return View(amounts);
        }

        // GET: Amount/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            var configuration = _configurations.FirstOrDefault(x => x.TypeName == amountModel.TypeName);
            amountModel.Id = amounts.Count+1;
            amountModel.TypeName = configuration.TypeName;
            amountModel.TypeOfAmount = configuration.TypeOfAmount;
            amounts.Add(amountModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Amount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Amount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Amount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Amount/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
