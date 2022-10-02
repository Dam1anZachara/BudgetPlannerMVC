using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace BudgetPlannerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlanTypeController : ControllerBase
    {
        private readonly IPlanTypeService _planTypeService;
        public PlanTypeController(IPlanTypeService planTypeService)
        {
            _planTypeService = planTypeService;
        }
        [SwaggerOperation("Operation gets filtered plan types")]
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult GetPlanTypes(int pageSize, int? pageNo, string searchString, int planId)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _planTypeService.GetAllPlanTypesForList(pageSize, pageNo.Value, searchString, planId);
            return Ok(model);
        }
        [SwaggerOperation("Operation adds plan type to plan")]
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public IActionResult AddPlanType(NewPlanTypeVm model)
        {
            var planTypeId = _planTypeService.AddPlanType(model);
            model.Id = planTypeId;
            return Created("", model);
        }
        [SwaggerOperation("Operation edits plan type")]
        [Authorize(Roles = "Admin, User")]
        [HttpPut]
        public IActionResult EditPlanType(NewPlanTypeVm model)
        {
            _planTypeService.UpdatePlanType(model);
            return NoContent();
        }
        [SwaggerOperation("Operation deletes plan type by id")]
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var planId = _planTypeService.DeletePlanType(id);
            return NoContent();
        }
    }
}
