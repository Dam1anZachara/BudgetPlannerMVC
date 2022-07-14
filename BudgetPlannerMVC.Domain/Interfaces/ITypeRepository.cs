using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Interfaces
{
    public interface ITypeRepository
    {
        IQueryable<Model.Type> GetAllTypes();
        int AddType(Model.Type type);
        void UpdateType(Model.Type type);
        void DeleteType(int id);
        IQueryable<Assign> GetAssigns();
    }
}
