﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseImplement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeNSurname { get; set; }
        [Required]
        public string EmployeeMiddlename { get; set; }
        [Required]
        public string EmployeePhoneNumber { get; set; }
        [Required]
        public string EmployeePrize { get; set; }
        [ForeignKey("StaffId")]
        public virtual List<Staff> Staff { get; set; }
        public virtual List<Repair> Repair { get; set; }

    }
}
