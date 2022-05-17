using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.AmountView;
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
        readonly IAmountRepository _amountRepository;
        readonly IMapper _mapper;

        public AmountService(IAmountRepository amountRepository, IMapper mapper)
        {
            _amountRepository = amountRepository;
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

        public List<string> DropDownTypes()
        {
            var types = _amountRepository.GetTypes().OrderBy(p => p.Assign.Id).
                ProjectTo<TypeForListVm>(_mapper.ConfigurationProvider).ToList();
            var dropDownTypes = new List<string>();
            foreach (var type in types)
            {
                dropDownTypes.Add(type.Name + " - " + type.Assign.Name);
            }
            return dropDownTypes;
        }

        public ListAmountForListVm GetAllAmountsForList(int pageSize, int pageNo, string searchString, DateTime startDate, DateTime endDate)
        {
            //var dateSelect = new DateSelectForListAmountVm()
            //{
            //    StartDate = startDate,
            //    EndDate = endDate
            //};

            var amounts = _amountRepository.GetAllAmounts().Where(p => p.Type.Name.StartsWith(searchString))
                .Where(t => t.Date >= startDate && t.Date <= endDate).OrderBy(d => d.Date)
                .ProjectTo<AmountForListVm>(_mapper.ConfigurationProvider).ToList();
            var amountsToShow = amounts.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();



            var sumExpenses = amounts.Where(et => et.Type.AssignId == 1).Sum(se => se.Value);
            var sumIncomes = amounts.Where(et => et.Type.AssignId == 2).Sum(se => se.Value);
            var sumValues = new SumValuesForListAmountVm()
            {
                SumOfExpenses = sumExpenses,
                SumOfIncomes = sumIncomes,
                Balance = sumIncomes - sumExpenses
            };

            var amountList = new ListAmountForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Amounts = amountsToShow,
                Count = amounts.Count,
                //DateSelect = dateSelect,
                StartDate = startDate,
                EndDate = endDate,
                SumValues = sumValues
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

        public int GetTypeIdByName(string nameOfType)
        {
            var indexOfAssignment = nameOfType.IndexOf("-");
            var nameOfTypeTrimmed = nameOfType.Remove(indexOfAssignment);
            var type = _amountRepository.GetTypes().First(p => p.Name == nameOfTypeTrimmed);
            var result = type.Id;
            return result;
        }

        public void UpdateAmount(NewAmountVm model)
        {
            var amount = _mapper.Map<Amount>(model);
            _amountRepository.UpdateAmount(amount);
        }
    }
}
