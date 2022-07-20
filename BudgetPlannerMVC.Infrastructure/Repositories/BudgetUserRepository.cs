using BudgetPlannerMVC.Domain.Interfaces;
using BudgetPlannerMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Infrastructure.Repositories
{
    public class BudgetUserRepository : IBudgetUserRepository
    {
        private readonly Context _context;
        public BudgetUserRepository(Context context)
        {
            _context = context;
        }
        public int AddBudgetUser(BudgetUser budgetUser)
        {
            _context.BudgetUsers.Add(budgetUser);
            _context.SaveChanges();
            return budgetUser.Id;
        }
        public void DeleteBudgetUser(int id)
        {
            var budgetUser = _context.BudgetUsers.Find(id);
            _context.BudgetUsers.Remove(budgetUser);
            _context.SaveChanges();
        }
        public void DeleteContactDetail(int id)
        {
            var contactDetail = _context.ContactDetails.Find(id);
            _context.ContactDetails.Remove(contactDetail);
            _context.SaveChanges();
        }
        public IQueryable<BudgetUser> GetAllBudgetUsers()
        {
            return _context.BudgetUsers;
        }
        public BudgetUser GetBudgetUser(int id)
        {
            return _context.BudgetUsers.FirstOrDefault(p => p.Id == id);
        }
        public void UpdateBudgetUser(BudgetUser budgetUser)
        {
            _context.Attach(budgetUser);
            _context.Entry(budgetUser).Property("FirstName").IsModified = true;
            _context.Entry(budgetUser).Property("LastName").IsModified = true;
            foreach (var item in budgetUser.ContactDetails)
            {
                _context.Entry(item).Property("ContactDetailInformation").IsModified = true;
                _context.Entry(item).Property("ContactDetailTypeId").IsModified = true;
            }
            _context.SaveChanges();
        }
        public IQueryable<ContactDetail> GetAllContactDetails()
        {
            return _context.ContactDetails;
        }
        public IQueryable<ContactDetailType> GetAllContactDetailTypes()
        {
            return _context.ContactDetailTypes;
        }
        public int AddAddres(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address.Id;
        }
        public void UpdateAddressForBudgetUser(Address address)
        {
            _context.Attach(address);
            _context.Entry(address).Property("Street").IsModified = true;
            _context.Entry(address).Property("BuildingNumber").IsModified = true;
            _context.Entry(address).Property("FlatNumber").IsModified = true;
            _context.Entry(address).Property("ZipCode").IsModified = true;
            _context.Entry(address).Property("City").IsModified = true;
            _context.Entry(address).Property("Country").IsModified = true;
            _context.SaveChanges();
        }
        public int AddContactDetail(ContactDetail contactDetail)
        {
            _context.ContactDetails.Add(contactDetail);
            _context.SaveChanges();
            return contactDetail.Id;
        }
    }
}
