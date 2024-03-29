﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.PlanView
{
    public class ListPlanTypesForListVm
    {
        public List<PlanTypeForListVm> PlanTypes { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
        public int PlanId { get; set; }
        public string PlanName { get; set; }
    }
}
