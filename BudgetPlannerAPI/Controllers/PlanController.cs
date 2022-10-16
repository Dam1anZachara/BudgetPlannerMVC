using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace BudgetPlannerAPI.Controllers
{
    [Authorize]
    [Route("api/plans")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        [SwaggerOperation("Operation gets filtered plans")]
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
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
        [SwaggerOperation("Operation adds new plan")]
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult AddPlan(NewPlanVm model)
        {
            var id = _planService.AddPlan(model);
            model.Id = id;  
            return Created("", model);
        }
        [SwaggerOperation("Operation edits plan")]
        [Authorize(Roles = "Admin, User")]
        [HttpPut]
        public IActionResult EditPlan(NewPlanVm model)
        {
            _planService.UpdatePlan(model);
            return NoContent();
        }
        [SwaggerOperation("Operation sets status of specific plan to \"Active\"")]
        [Authorize(Roles = "Admin, User")]
        [HttpPut("{id}")]
        public IActionResult Status(int id)
        {
            var plans = _planService.StatusPlan(id);
            _planService.UpdateListOfPlans(plans);
            return NoContent();
        }
        [SwaggerOperation("Operation deletes plan by id")]
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _planService.DeletePlan(id);
            return NoContent();
        }
    }
}
