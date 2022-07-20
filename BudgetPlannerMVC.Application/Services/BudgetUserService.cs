using AutoMapper;
using AutoMapper.QueryableExtensions;
using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using BudgetPlannerMVC.Application.ViewModels.UserView;
using BudgetPlannerMVC.Domain.Interfaces;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Services
{
    public class BudgetUserService : IBudgetUserService
    {
        private readonly IBudgetUserRepository _budgetUserRepository;
        private readonly IAmountRepository _amountRepository;
        private readonly IMapper _mapper;
        public BudgetUserService(IBudgetUserRepository budgetUserRepository, IAmountRepository amountRepository, IMapper mapper)
        {
            _budgetUserRepository = budgetUserRepository;
            _amountRepository = amountRepository;
            _mapper = mapper;
        }
        public int AddBudgetUser(NewBudgetUserVm budgetUser)
        {
            var newBudgetUser = _mapper.Map<BudgetUser>(budgetUser);
            var id = _budgetUserRepository.AddBudgetUser(newBudgetUser);
            return id;
        }
        public int AddAddressForBudgetUser(NewBudgetUserVm budgetUser, int budgetUserId)
        {
            budgetUser.Address.BudgetUserId = budgetUserId;
            var newAddress = _mapper.Map<Address>(budgetUser.Address);
            var addressId = _budgetUserRepository.AddAddres(newAddress);
            return addressId;
        }
        public int CountContactDetailsForAddBudgetUser(NewBudgetUserVm budgetUser, string addContact, string removeContact)
        {
            var allContactTypes = budgetUser.CountContactDetailsType;
            if (addContact != null)
            {
                allContactTypes++;
                var contactDetail = new ContactDetailVm() {};
                if(budgetUser.ContactDetails != null)
                {
                    budgetUser.ContactDetails.Add(contactDetail);
                }
            }
            if (removeContact != null && budgetUser.CountContactDetailsType != 0)
            {
                allContactTypes--;
            }
            return allContactTypes;
        }
        public void DeleteBudgetUser(int id)
        {
            _amountRepository.ChangeBudgetUserInAmountOnDelete(id); 
            _budgetUserRepository.DeleteBudgetUser(id);
        }
        public IQueryable<BudgetUserVm> DropDownBudgetUsers()
        {
            var budgetUsers = _budgetUserRepository.GetAllBudgetUsers().OrderBy(s => s.LastName)
                .ProjectTo<BudgetUserVm>(_mapper.ConfigurationProvider);
            return budgetUsers;
        }
        public ListBudgetUserForListVm GetAllBudgetUsersForList(int pageSize, int pageNo, string searchString)
        {
            var budgetUsers = _budgetUserRepository.GetAllBudgetUsers()
                .Where(p => p.FirstName.StartsWith(searchString) || p.LastName.StartsWith(searchString)
                || (p.LastName + " " + p.FirstName).StartsWith(searchString) || (p.FirstName + " " + p.LastName).StartsWith(searchString))
                .Where(a => a.Id > 1).OrderBy(c => c.LastName).ProjectTo<BudgetUserForListVm>(_mapper.ConfigurationProvider).ToList();
            var budgetUsersToShow = budgetUsers.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            var budgetUserList = new ListBudgetUserForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                BudgetUsers = budgetUsersToShow,
                Count = budgetUsers.Count,
            };
            return budgetUserList;
        }
        public NewBudgetUserVm GetBudgetUserForEdit(int id)
        {
            var budgetUsers = _budgetUserRepository.GetAllBudgetUsers().Where(p => p.Id == id)
                .ProjectTo<NewBudgetUserVm>(_mapper.ConfigurationProvider).ToList();
            var budgetUserVm = budgetUsers.FirstOrDefault(a => a.Id == id);
            budgetUserVm.Address = budgetUserVm.Addresses.FirstOrDefault(a => a.BudgetUserId == id);
            return budgetUserVm;
        }
        public void UpdateBudgetUser(NewBudgetUserVm model)
        {
            var budgetUser = _mapper.Map<BudgetUser>(model);
            _budgetUserRepository.UpdateBudgetUser(budgetUser);
            UpdateAdressForBudgetUser(model);
            AddDeleteContactDetailsForBudgetUserEdit(model);
        }
        public IQueryable<ContactDetailTypeVm> DropDownContactDetailTypes()
        {
            var detailTypesVm = _budgetUserRepository.GetAllContactDetailTypes()
                .ProjectTo<ContactDetailTypeVm>(_mapper.ConfigurationProvider);
            return detailTypesVm;
        }
        private void UpdateAdressForBudgetUser(NewBudgetUserVm model)
        {
            var address = _mapper.Map<Address>(model.Address);
            _budgetUserRepository.UpdateAddressForBudgetUser(address);
        }
        private void AddDeleteContactDetailsForBudgetUserEdit(NewBudgetUserVm model)
        {
            var allContactDetails = AllContactDetailsForBudgetUserEdit(model);
            if (model.ContactDetails.Count != allContactDetails.Count)
            {
                DeleteContactDetailsForBudgetUserEdit(allContactDetails);
                AddContactDetailsForBudgetUserEdit(model);
            }
        }
        private List<ContactDetailVm> AllContactDetailsForBudgetUserEdit(NewBudgetUserVm model)
        {
            var allContactDetails = _budgetUserRepository.GetAllContactDetails().Where(p => p.BudgetUserId == model.Id)
                .ProjectTo<ContactDetailVm>(_mapper.ConfigurationProvider).ToList();
            return allContactDetails;
        }
        private void DeleteContactDetailsForBudgetUserEdit(List<ContactDetailVm> allContactDetails)
        {
            foreach (var oldContact in allContactDetails)
            {
                _budgetUserRepository.DeleteContactDetail(oldContact.Id);
            }
        }
        private void AddContactDetailsForBudgetUserEdit(NewBudgetUserVm model)
        {
            foreach (var newContact in model.ContactDetails)
            {
                newContact.Id = 0;
                newContact.BudgetUserId = model.Id;
                var newContactDetail = _mapper.Map<ContactDetail>(newContact);
                var contactId = _budgetUserRepository.AddContactDetail(newContactDetail);
            }
        }
    }
}
