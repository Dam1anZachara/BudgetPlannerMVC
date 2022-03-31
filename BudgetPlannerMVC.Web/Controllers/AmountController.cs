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
        private static IList<AmountModel> amounts = new List<AmountModel>();
        // GET: AmountController
        public ActionResult Index()
        {
            return View(amounts);
        }

        // GET: AmountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AmountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AmountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AmountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AmountController/Edit/5
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

        // GET: AmountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AmountController/Delete/5
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
