using BuisnessLogic.Enums;
using System;

namespace BuisnessLogic.ViewModels
{
    public class RepairViewModel
    {
        public int Id { get; set; }
        public string RepairName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public int Sum { get; set; }
        public int? EmployeeId { get; set; }
        public RepairStatus Status { get; set; }
    }
}
