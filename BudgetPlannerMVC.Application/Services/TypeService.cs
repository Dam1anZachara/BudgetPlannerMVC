﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using BudgetPlannerMVC.Domain.Interfaces;
using BudgetPlannerMVC.Domain.Model;
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
            var newType = _mapper.Map<Type>(type);
            var id = _typeRepository.AddType(newType);
            return id;
        }
        public void DeleteType(int id)
        {
            _typeRepository.DeleteType(id);
        }
        public ListTypeForListVm GetAllTypesForList(int pageSize, int pageNo, string searchString)
        {
            var types = _typeRepository.GetAllTypes()
                .Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<TypeForListVm>(_mapper.ConfigurationProvider).ToList();
            var typesToShow = types.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var typeList = new ListTypeForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Types = typesToShow,
                Count = types.Count
            };
            return typeList;
        }
        public NewTypeVm GetTypeForEdit(int id)
        {
            var types = _typeRepository.GetAllTypes()
                .Where(p => p.Id == id).ProjectTo<NewTypeVm>(_mapper.ConfigurationProvider).ToList();
            var typeVm = types.FirstOrDefault(x => x.Id == id);
            return typeVm;
        }
        public void UpdateType(NewTypeVm model)
        {
            var type = _mapper.Map<Type>(model);
            _typeRepository.UpdateType(type);
        }
        public IQueryable<TypeVm> DropDownTypes()
        {
            var types = _typeRepository.GetAllTypes().OrderBy(p => p.Assign.Id)
                .ProjectTo<TypeVm>(_mapper.ConfigurationProvider);
            return types;
        }
        public IQueryable<AssignForTypeVm> DropDownAssigns()
        {
            var assigns = _typeRepository.GetAssigns()
                .ProjectTo<AssignForTypeVm>(_mapper.ConfigurationProvider);
            return assigns;
        }
    }
}
