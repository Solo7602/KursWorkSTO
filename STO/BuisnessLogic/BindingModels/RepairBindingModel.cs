using BuisnessLogic.Enums;
using System;
using System.Collections.Generic;

namespace BuisnessLogic.BindingModels
{
    public class RepairBindingModel
    {
        public int? Id { get; set; }
        public int Sum { get; set; }
        public string Name { get; set; }
        public int? ClientId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public RepairStatus Status { get; set; }
        public int? EmployeeId { get; set; }
        public Dictionary<int, string> repairWorks { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public int WorkId { get; set; }
    }
}
