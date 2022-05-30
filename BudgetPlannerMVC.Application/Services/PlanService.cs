using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using BudgetPlannerMVC.Domain.Interfaces;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;
        public PlanService(IPlanRepository planRepository, IMapper mapper)
        {
            _planRepository = planRepository;
            _mapper = mapper;
        }
        public int AddPlan(NewPlanVm plan)
        {
            var newPlan = _mapper.Map<Plan>(plan);
            var id = _planRepository.AddPlan(newPlan);
            return id;
        }

        public void DeletePlan(int id)
        {
            _planRepository.DeletePlan(id);
        }

        //public List<string> DropDownTypes()
        //{
        //    //var types = _amountRepository.GetTypes().OrderBy(p => p.Assign.Id).
        //    var types = _typeRepository.GetAllTypes().OrderBy(p => p.Assign.Id).
        //        ProjectTo<TypeForListVm>(_mapper.ConfigurationProvider).ToList();
        //    var dropDownTypes = new List<string>();
        //    foreach (var type in types)
        //    {
        //        dropDownTypes.Add(type.Name + " - " + type.Assign.Name);
        //    }
        //    return dropDownTypes;
        //}

        public ListPlanForListVm GetAllPlansForList(int pageSize, int pageNo, string searchString)
        {
            var plans = _planRepository.GetAllPlans().Where(p => p.Name.StartsWith(searchString))
                .OrderByDescending(d => d.DateStart)
                .ProjectTo<PlanForListVm>(_mapper.ConfigurationProvider).ToList();
            var plansToShow = plans.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            var planList = new ListPlanForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Plans = plansToShow,
                Count = plans.Count,
            };
            return planList;
        }

        //public NewAmountVm GetAmountForEdit(int id)
        //{
        //    var amounts = _amountRepository.GetAllAmounts().Where(p => p.Id == id)
        //        .ProjectTo<NewAmountVm>(_mapper.ConfigurationProvider).ToList();
        //    var amountVm = amounts.FirstOrDefault(a => a.Id == id);
        //    return amountVm;
        //}


        //public void UpdateAmount(NewAmountVm model)
        //{
        //    var amount = _mapper.Map<Amount>(model);
        //    _amountRepository.UpdateAmount(amount);
        //}
    }
}
