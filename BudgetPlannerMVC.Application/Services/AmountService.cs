using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.AmountView;
using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using BudgetPlannerMVC.Domain.Interfaces;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Services
{
    public class AmountService : IAmountService
    {
        private readonly IAmountRepository _amountRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly IBudgetUserRepository _budgetUserRepository;
        private readonly IMapper _mapper;

        public AmountService(IAmountRepository amountRepository, ITypeRepository typeRepository, IBudgetUserRepository budgetUserRepository, IMapper mapper)
        {
            _amountRepository = amountRepository;
            _typeRepository = typeRepository;
            _budgetUserRepository = budgetUserRepository;
            _mapper = mapper;
        }

        public int AddAmount(NewAmountVm amount)
        {
            var newAmount = _mapper.Map<Amount>(amount);
            var id = _amountRepository.AddAmount(newAmount);
            return id;
        }
        public void DeleteAmount(int id)
        {
            _amountRepository.DeleteAmount(id);
        }

        public List<AmountForListVm> GetFiltredAmountsForList(FilterForAmountForListAmount filterForAmount, DateSelectForListAmountVm dateSelect)
        {
            var startDate = dateSelect.StartDate;
            var endDate = dateSelect.EndDate.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);
            var amounts = _amountRepository.GetAllAmounts()
                .Where(t => t.Date >= startDate && t.Date <= endDate).OrderByDescending(d => d.Date)
                .ProjectTo<AmountForListVm>(_mapper.ConfigurationProvider).ToList();

            var amountsFiltered = new List<AmountForListVm>();
            if (filterForAmount.SearchTypeId == 0 && filterForAmount.SearchUserId == 0)
            {
                amountsFiltered = amounts;  
            }
            else if (filterForAmount.SearchTypeId != 0 && filterForAmount.SearchUserId == 0)
            {
                amountsFiltered = amounts
                    .Where(p => p.TypeId == filterForAmount.SearchTypeId).ToList();
            }
            else if (filterForAmount.SearchTypeId == 0 && filterForAmount.SearchUserId != 0)
            {
                amountsFiltered = amounts.Where(p => p.BudgetUserId == filterForAmount.SearchUserId).ToList();
            }
            else
            {
                amountsFiltered = amounts.Where(p => p.BudgetUserId == filterForAmount.SearchUserId
                && p.TypeId == filterForAmount.SearchTypeId).ToList();
            }
            return amountsFiltered;
        }
        public TypeAndUserSelectedForListAmount SelectedUserNameForListAmount(FilterForAmountForListAmount filterForAmount)
        {
            var budgetUser = _budgetUserRepository.GetBudgetUser(filterForAmount.SearchUserId);
            var budgetUserVm = _mapper.Map<BudgetUserVm>(budgetUser);
            var budgetUserNameVm = "All Budget Users";
            if (budgetUserVm != null)
            {
                budgetUserNameVm = budgetUserVm.FullName;
            }

            var types = _typeRepository.GetAllTypes().OrderBy(p => p.Assign.Id)
                .ProjectTo<TypeVm>(_mapper.ConfigurationProvider);
            var typeVm = types.FirstOrDefault(t => t.Id == filterForAmount.SearchTypeId);

            var typeNameVm = "All Types";
            if (typeVm != null)
            {
                typeNameVm = typeVm.NameAndAssign;
            }

            var typeUserName = new TypeAndUserSelectedForListAmount()
            {
                SelectedUserName = budgetUserNameVm,
                SelectedTypeName = typeNameVm
            };
            return typeUserName;
        }
        public SumValuesForListAmountVm GetSumValuesForListAmount(List<AmountForListVm> amounts)
        {
            var sumExpenses = amounts.Where(et => et.Type.AssignId == 1).Sum(se => se.Value);
            var sumIncomes = amounts.Where(et => et.Type.AssignId == 2).Sum(se => se.Value);
            var sumValues = new SumValuesForListAmountVm()
            {
                SumOfExpenses = sumExpenses,
                SumOfIncomes = sumIncomes,
                Balance = sumIncomes - sumExpenses
            };
            return sumValues;
        }
        public ListAmountForListVm GetAllAmountsForList(int pageSize, int pageNo, SumValuesForListAmountVm sumValues, TypeAndUserSelectedForListAmount typeUserName, List<AmountForListVm> amounts, DateSelectForListAmountVm dateSelect)
        {
            var amountsToShow = amounts.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            var amountList = new ListAmountForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                Amounts = amountsToShow,
                Count = amounts.Count,
                DateSelect = dateSelect,
                SumValues = sumValues,
                TypeUserName = typeUserName
            };
            return amountList;
        }
        public NewAmountVm GetAmountForEdit(int id)
        {
            var amounts = _amountRepository.GetAllAmounts().Where(p => p.Id == id)
                .ProjectTo<NewAmountVm>(_mapper.ConfigurationProvider).ToList();
            var amountVm = amounts.FirstOrDefault(a => a.Id == id);
            return amountVm;
        }
        public DateSelectForListAmountVm GetDateSelect(DateTime startDate, DateTime endDate)
        {
            var dateSelect = new DateSelectForListAmountVm()
            {
                StartDate = startDate,
                EndDate = endDate
            };
            return dateSelect;
        }
        public void UpdateAmount(NewAmountVm model)
        {
            var amount = _mapper.Map<Amount>(model);
            _amountRepository.UpdateAmount(amount);
        }
    }
}
