using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Web.Models
{
    public class ConfigurationModel
    {
        public int Id { get; set; }
        [DisplayName("Type name")]
        [Required]
        public string TypeName { get; set; }
        [DisplayName("Type of amount")]
        public TypeOfAmount TypeOfAmount { get; set; }
    }
    public enum TypeOfAmount
    {
        Expense,
        Income
    }
}
