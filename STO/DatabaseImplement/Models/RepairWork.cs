using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Models
{
    public class RepairWork
    {
        public int Id { get; set; }
        public int? RepairId { get; set; }
        public int WorkId { get; set; }
        public Repair Repair { get; set; }
        public Work Work { get; set; }
    }
}
