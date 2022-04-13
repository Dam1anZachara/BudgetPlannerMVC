using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }

        public UserPersonalData UserPersonalData { get; set; }

        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
