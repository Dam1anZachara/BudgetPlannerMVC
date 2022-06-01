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
    public class PlanTypeService : IPlanTypeService
    {
        private readonly IPlanTypeRepository _planTypeRepository;
        private readonly IMapper _mapper;
        public PlanTypeService(IPlanTypeRepository planTypeRepository, IMapper mapper)
        {
            _planTypeRepository = planTypeRepository;
            _mapper = mapper;
        }

        public int AddPlanType(NewPlanTypeVm planType)
        {
            var newPlanType = _mapper.Map<PlanType>(planType);
            var id = _planTypeRepository.AddPlanType(newPlanType);
            return id;
        }
        public void DeletePlanType(int id)
        {
            _planTypeRepository.DeletePlanType(id);
        }
        public ListPlanTypesForListVm GetAllPlanTypesForList(int pageSize, int pageNo, string searchString, int planId)
        {
            var planTypes = _planTypeRepository.GetAllPlanTypes().Where(p => p.Type.Name.StartsWith(searchString))
                .Where(a => a.PlanId == planId).OrderBy(d => d.Type.AssignId)
                .ProjectTo<PlanTypeForListVm>(_mapper.ConfigurationProvider).ToList();
            var planTypesToShow = planTypes.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            var planTypeList = new ListPlanTypesForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                PlanTypes = planTypesToShow,
                Count = planTypes.Count,
            };
            return planTypeList;
        }
        public NewPlanTypeVm GetPlanTypeForEdit(int id)
        {
            var planTypes = _planTypeRepository.GetAllPlanTypes().Where(p => p.Id == id)
                .ProjectTo<NewPlanTypeVm>(_mapper.ConfigurationProvider).ToList();
            var planTypeVm = planTypes.FirstOrDefault(a => a.Id == id);
            return planTypeVm;
        }
        public void UpdatePlanType(NewPlanTypeVm model)
        {
            var planType = _mapper.Map<PlanType>(model);
            _planTypeRepository.UpdatePlanType(planType);
        }
    }
}
