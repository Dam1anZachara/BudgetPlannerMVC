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
        public NewPlanVm GetPlanForEdit(int id)
        {
            var plans = _planRepository.GetAllPlans().Where(p => p.Id == id)
                .ProjectTo<NewPlanVm>(_mapper.ConfigurationProvider).ToList();
            var planVm = plans.FirstOrDefault(a => a.Id == id);
            return planVm;
        }
        public void UpdatePlan(NewPlanVm model)
        {
            var plan = _mapper.Map<Plan>(model);
            _planRepository.UpdatePlan(plan);
        }
        public void UpdateListOfPlans(ListPlanForListVm plans)
        {
            foreach (var item in plans.Plans)
            {
                var newPlanVm = new NewPlanVm()
                {
                    Id = item.Id,
                    IsActive = item.IsActive,
                    DateStart = item.DateStart,
                    DateEnd = item.DateEnd,
                    Name = item.Name
                };
                var plan = _mapper.Map<Plan>(newPlanVm);
                _planRepository.UpdatePlan(plan);
            }
        }
        public ListPlanForListVm StatusPlan(int id)
        {
            var plans = _planRepository.GetAllPlans()
                .ProjectTo<PlanForListVm>(_mapper.ConfigurationProvider).ToList();
            foreach (var item in plans)
            {
                if (item.Id == id)
                {
                    item.IsActive = true;
                }
                else
                {
                    item.IsActive = false;
                }
            }
            var actualizedPlans = new ListPlanForListVm()
            {
                Plans = plans,
            };
            return actualizedPlans;
        } 
    }
}
