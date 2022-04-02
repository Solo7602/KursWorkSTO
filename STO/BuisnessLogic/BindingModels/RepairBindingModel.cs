﻿using BuisnessLogic.Enums;
using System;

namespace BuisnessLogic.BindingModels
{
    public class RepairBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public RepairStatus Status { get; set; }
        public int ? EmployeeId { get; set; }
    }
}
