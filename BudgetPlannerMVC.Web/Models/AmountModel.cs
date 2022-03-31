using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Web.Models
{
    public class AmountModel
    {
        public int Id { get; set; }
        [DisplayName("Type name")]
        public string TypeName { get; set; }
        [DisplayName("Type of amount")]
        public TypeOfAmount TypeOfAmount { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
