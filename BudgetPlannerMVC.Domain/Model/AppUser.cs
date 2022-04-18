using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Model
{
    public class AppUser
    {
        public int Id { get; set; }
        public string NickName { get; set; }

        public AppUserPersonalData AppUserPersonalData { get; set; }

        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
