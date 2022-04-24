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
