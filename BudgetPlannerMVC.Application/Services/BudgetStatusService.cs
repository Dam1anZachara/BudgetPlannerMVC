using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.BudgetStatusView;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using BudgetPlannerMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Services
{
    public class BudgetStatusService : IBudgetStatusService
    {
        private readonly IAmountRepository _amountRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IPlanTypeRepository _planTypeRepository;
        private readonly IMapper _mapper;
        public BudgetStatusService(IAmountRepository amountRepository, IPlanRepository planRepository, IPlanTypeRepository planTypeRepository, IMapper mapper)
        {
            _amountRepository = amountRepository;
            _planRepository = planRepository;
            _planTypeRepository = planTypeRepository;
            _mapper = mapper;
        }

        public BudgetStatusVm GetBudgetStatusForVm()
        {
            var plan = _planRepository.GetAllPlans().FirstOrDefault(p => p.IsActive == true);

            SumValuesForBudgetStatusVm sumValues = new SumValuesForBudgetStatusVm();
            List<PlanTypeForBudgetStatusVm> planTypes = new List<PlanTypeForBudgetStatusVm>();
            if (plan != null)
            {
                planTypes = _planTypeRepository.GetAllPlanTypes().Where(pt => pt.PlanId == plan.Id).OrderBy(x => x.Type.AssignId)
                    .ProjectTo<PlanTypeForBudgetStatusVm>(_mapper.ConfigurationProvider).ToList();
                
                foreach (var item in planTypes)
                {
                    var sumAmounts = _amountRepository.GetAllAmounts()
                        .Where(x => x.Date >= plan.DateStart && x.Date <= plan.DateEnd && x.TypeId == item.TypeId)
                        .Sum(v => v.Value);
                    item.AmountValues = sumAmounts;
                    item.DifferenceValue = item.Value - sumAmounts;
                }
            }

            BudgetStatusVm budgetStatusVm = new BudgetStatusVm()
            {
                PlanTypes = planTypes,
                SumValues = sumValues
            };
            return budgetStatusVm;
        }
    }
}
