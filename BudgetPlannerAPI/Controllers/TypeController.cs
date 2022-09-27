using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BudgetPlannerAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;
        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin, User")]
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
        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin, User")]
        public IActionResult GetTypeDetails(int id)
        {
            var type = _typeService.GetTypeForEdit(id);
            return Ok(type);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, User")]
        public IActionResult AddType(NewTypeVm model)
        {
            var id = _typeService.AddType(model);
            model.Id = id;
            return Created("", model);
        }
        [HttpPut]
        //[ValidateAntiForgeryToken] //kod 400 jeśli pomijana jest autoryzacja
        //[Authorize(Roles = "Admin, User")]
        public IActionResult EditType(NewTypeVm model)
        {
            _typeService.UpdateType(model);
            return NoContent();
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _typeService.DeleteType(id);
            return NoContent();
        }
    }
}
