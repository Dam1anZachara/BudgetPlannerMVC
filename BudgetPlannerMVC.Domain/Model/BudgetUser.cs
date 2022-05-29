using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Model
{
    public class BudgetUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
