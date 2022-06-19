using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.AmountView;
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

        public BudgetStatusVm GetBudgetStatusForVm(List<PlanTypeForBudgetStatusVm> planTypes, SumValuesForBudgetStatusVm sumValues)
        {
            BudgetStatusVm budgetStatusVm = new BudgetStatusVm()
            {
                PlanTypes = planTypes,
                SumValues = sumValues
            };
            return budgetStatusVm;
        }
        public PlanForListVm GetActivePlanToBudgetStatusVm()
        {
            return _planRepository.GetAllPlans().ProjectTo<PlanForListVm>(_mapper.ConfigurationProvider)
                .FirstOrDefault(p => p.IsActive == true);
        }
        public List<PlanTypeForBudgetStatusVm> GetPlanTypesOfPlanForBudgetStatusVm(PlanForListVm plan)
        {
            List<PlanTypeForBudgetStatusVm> planTypes = new List<PlanTypeForBudgetStatusVm>();
            if (plan != null)
            {
                planTypes = _planTypeRepository.GetAllPlanTypes().Where(pt => pt.PlanId == plan.Id).OrderBy(x => x.Type.AssignId)
                    .ProjectTo<PlanTypeForBudgetStatusVm>(_mapper.ConfigurationProvider).ToList();

                foreach (var item in planTypes)
                {
                    var sumAmounts = _amountRepository.GetAllAmounts().ProjectTo<AmountForListVm>(_mapper.ConfigurationProvider)
                        .Where(x => x.Date >= plan.DateStart && x.Date <= plan.DateEnd && x.TypeId == item.TypeId)
                        .Sum(v => v.Value);
                    item.AmountValues = sumAmounts;
                    item.DifferenceValue = item.Value - sumAmounts;
                }
            }
            return planTypes;
        }
        public SumValuesForBudgetStatusVm GetSumValuesForBudgetStatusVm(List<PlanTypeForBudgetStatusVm> planTypes, List<AmountForListVm> amounts)
        {
            var sumOfExpPlan = planTypes.Where(p => p.Type.AssignId == 1).Sum(x => x.AmountValues);
            var sumOfIncPlan = planTypes.Where(p => p.Type.AssignId == 2).Sum(x => x.AmountValues);
            var sumOfExpOutOfPlan = amounts.Where(p => p.Type.AssignId == 1).Sum(x => x.Value);
            var sumOfIncOutOfPlan = amounts.Where(p => p.Type.AssignId == 2).Sum(x => x.Value);
            var expensesTotal = sumOfExpPlan + sumOfExpOutOfPlan;
            var incomesTotal = sumOfIncPlan + sumOfIncOutOfPlan;

            SumValuesForBudgetStatusVm sumValues = new SumValuesForBudgetStatusVm()
            {
                SumOfExpPlan = sumOfExpPlan,
                SumOfIncPlan = sumOfIncPlan,
                BalancePlan = sumOfIncPlan - sumOfExpPlan,
                SumOfExpOutOfPlan = sumOfExpOutOfPlan,
                SumOfIncOutOfPlan = sumOfIncOutOfPlan,
                BalanceOutOfPlan = sumOfIncOutOfPlan - sumOfExpOutOfPlan,
                ExpensesTotal = expensesTotal,
                IncomesTotal = incomesTotal,
                BalanceTotal = incomesTotal - expensesTotal,
            };
            return sumValues;
        }
        public List<AmountForListVm> GetAmountsOutOfPlan(PlanForListVm plan, List<PlanTypeForBudgetStatusVm> planTypes)
        {
            List<AmountForListVm> amountsOutOfPlan = new List<AmountForListVm>();

            if (plan != null)
            {
                var amounts = _amountRepository.GetAllAmounts().ProjectTo<AmountForListVm>(_mapper.ConfigurationProvider)
                        .Where(x => x.Date >= plan.DateStart && x.Date <= plan.DateEnd).ToList();

                foreach (var amount in amounts)
                {
                    var counter = 0;
                    foreach (var planType in planTypes)
                    {
                        if (amount.TypeId == planType.TypeId)
                        {
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        amountsOutOfPlan.Add(amount);
                    }
                }
            }
            return amountsOutOfPlan;
        }
    }
}
