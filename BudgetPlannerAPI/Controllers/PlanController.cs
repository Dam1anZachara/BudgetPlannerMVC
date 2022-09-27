using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BudgetPlannerAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin, User")]
        public IActionResult GetPlans(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _planService.GetAllPlansForList(pageSize, pageNo.Value, searchString);
            return Ok(model);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, User")]
        public IActionResult AddPlan(NewPlanVm model)
        {
            var id = _planService.AddPlan(model);
            model.Id = id;  
            return Created("", model);
        }
        [HttpPut]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, User")]
        public IActionResult EditPlan(NewPlanVm model)
        {
            _planService.UpdatePlan(model);
            return NoContent();
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin, User")]
        public IActionResult Status(int id)
        {
            var plans = _planService.StatusPlan(id);
            _planService.UpdateListOfPlans(plans);
            return NoContent();
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int id)
        {
            _planService.DeletePlan(id);
            return NoContent();
        }
    }
}
