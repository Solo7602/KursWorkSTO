using BuisnessLogic.Enums;
using System;
using System.Collections.Generic;

namespace BuisnessLogic.ViewModels
{
    public class RepairViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public decimal Sum { get; set; }
        public int? ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public Dictionary<int,string> repairWorks { get; set; }
        public RepairStatus Status { get; set; }
    }
}
