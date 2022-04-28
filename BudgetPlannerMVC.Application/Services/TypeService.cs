using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using BudgetPlannerMVC.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BudgetPlannerMVC.Application.Services
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;
        public TypeService(ITypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;  
        }
        public int AddType(NewTypeVm type)
        {
            throw new System.NotImplementedException();
        }
        
        public ListTypeForListVm GetAllExpenseTypesForList(int pageSize, int pageNo, string searchString)
        {
            var expenseTypes = _typeRepository.GetAllExpenseTypes().Where(p => p.Name == searchString)
                .ProjectTo<TypeForListVm>(_mapper.ConfigurationProvider).ToList();
            var typesToShow = expenseTypes.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var expenseTypeList = new ListTypeForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Types = expenseTypes,
                Count = expenseTypes.Count
            };
            return expenseTypeList;
        }

        public ListTypeForListVm GetAllIncomeTypesForList()
        {
            var incomeTypes = _typeRepository.GetAllIncomeTypes()
                .ProjectTo<TypeForListVm>(_mapper.ConfigurationProvider).ToList();
            var incomeTypeList = new ListTypeForListVm()
            {
                Types = incomeTypes,
                Count = incomeTypes.Count
            };
            return incomeTypeList;
        }

        public ListTypeForListVm GetAllTypesForList()
        {
            var types = _typeRepository.GetAllTypes()
                .ProjectTo<TypeForListVm>(_mapper.ConfigurationProvider).ToList();
            var typeList = new ListTypeForListVm()
            {
                Types = types,
                Count = types.Count
            };
            return typeList;
        }
    }
}
