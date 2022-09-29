using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
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
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult AddPlanType(NewPlanTypeVm model)
        {
            var planTypeId = _planTypeService.AddPlanType(model);
            model.Id = planTypeId;
            return Created("", model);
        }
        [HttpPut]
        [Authorize(Roles = "Admin, User")]
        public IActionResult EditPlanType(NewPlanTypeVm model)
        {
            _planTypeService.UpdatePlanType(model);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var planId = _planTypeService.DeletePlanType(id);
            return NoContent();
        }
    }
}
