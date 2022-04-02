using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;


namespace DatabaseImplement.Implements
{
    public class StoDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Database=StoDatabase;Trusted_Connection=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Employee> Employees { set; get; }
        public virtual DbSet<Staff> Staffs { set; get; }
        public virtual DbSet<Work> Works { set; get; }
    }
}
