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
        public string UserId { get; set; } 
        public string UserName { get; set; } 
        public string MainMail { get; set; }
        public bool ProfileCreated { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
