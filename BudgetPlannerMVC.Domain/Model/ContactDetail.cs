using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Model
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public string ContactDetailInformation { get; set; }
        public int ContactDetailTypeId { get; set; }
        public ContactDetailType ContactDetailType { get; set; }
        public int BudgetUserId { get; set; }
        public BudgetUser BudgetUser { get; set; }



    }
}
