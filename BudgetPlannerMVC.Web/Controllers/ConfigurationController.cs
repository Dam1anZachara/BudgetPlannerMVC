using BudgetPlannerMVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class ConfigurationController : Controller
    {
        private static IList<ConfigurationModel> configurations = new List<ConfigurationModel>()
        {
            new ConfigurationModel(){ Id = 1, TypeName = "General expenses", TypeOfAmount = TypeOfAmount.Expense},
            new ConfigurationModel(){ Id = 2, TypeName = "General incomes", TypeOfAmount = TypeOfAmount.Income}
        };
        private static IList<string> typesOfAmount = new List<string>() 
        {
            TypeOfAmount.Expense.ToString(),
            TypeOfAmount.Income.ToString()
        };

        public List<ConfigurationModel> GetAllConfigModels() => configurations.ToList();

        // GET: Configuration
        public ActionResult Index()
        {
            return View(configurations);
        }

        // GET: Configuration/Details/5
        public ActionResult Details(int id)
        {
            return View(configurations.FirstOrDefault(p => p.Id == id));
        }

        // GET: Configuration/Create
        public ActionResult Create()
        {
            ViewBag.list = typesOfAmount;
            return View(new ConfigurationModel());
        }

        // POST: Configuration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConfigurationModel configurationModel)
        {
            configurationModel.Id = configurations.Count + 1;
            configurations.Add(configurationModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Configuration/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.list = typesOfAmount;
            return View(configurations.FirstOrDefault(p => p.Id == id));
        }

        // POST: Configuration/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConfigurationModel configurationModel)
        {
            ConfigurationModel configuration = configurations.FirstOrDefault(p => p.Id == id);
            configuration.TypeName = configurationModel.TypeName;
            configuration.TypeOfAmount = configurationModel.TypeOfAmount;

            return RedirectToAction(nameof(Index));
        }

        // GET: Configuration/Delete/5
        public ActionResult Delete(int id)
        {
            return View(configurations.FirstOrDefault(p => p.Id == id));
        }

        // POST: Configuration/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ConfigurationModel configurationModel)
        {
            ConfigurationModel configuration = configurations.FirstOrDefault(p => p.Id == id);
            configurations.Remove(configuration);
            return RedirectToAction(nameof(Index));
        }
    }
}
