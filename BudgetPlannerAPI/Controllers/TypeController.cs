using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace BudgetPlannerAPI.Controllers
{
    [Authorize]
    [Route("api/types")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;
        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }
        [SwaggerOperation("Operation gets filtered types")]
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult GetTypes(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _typeService.GetAllTypesForList(pageSize, pageNo.Value, searchString);
            return Ok(model);
        }
        [SwaggerOperation("Operation gets specific type by id")]
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public IActionResult GetTypeDetails(int id)
        {
            var type = _typeService.GetTypeForEdit(id);
            return Ok(type);
        }
        [SwaggerOperation("Operation adds new type")]
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public IActionResult AddType(NewTypeVm model)
        {
            var id = _typeService.AddType(model);
            model.Id = id;
            return Created("", model);
        }
        [SwaggerOperation("Operation edits type")]
        [Authorize(Roles = "Admin, User")]
        [HttpPut]
        public IActionResult EditType(NewTypeVm model)
        {
            _typeService.UpdateType(model);
            return NoContent();
        }
        [SwaggerOperation("Operation deletes type by id")]
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _typeService.DeleteType(id);
            return NoContent();
        }
    }
}
