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

        public ListAmountForListVm GetAllAmountsForList(int pageSize, int pageNo, string searchString)
        {
            var amounts = _amountRepository.GetAllAmounts().Where(p => p.Type.Name.StartsWith(searchString))
                .ProjectTo<AmountForListVm>(_mapper.ConfigurationProvider).ToList();
            var amountsToShow = amounts.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var amountList = new ListAmountForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Amounts = amountsToShow,
                Count = amounts.Count,
            };
            return amountList;
        }

        public NewAmountVm GetAmountForEdit(int id)
        {
            var amount = _amountRepository.GetAmount(id);
            var amountVm = _mapper.Map<NewAmountVm>(amount);
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
