using EmployeeForms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace EmployeeForms
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<EmpDetails> employeeDetailsList { get; set; }
        public DbSet<EmpBankDetails> bankDetailsList { get; set; }
        public DbSet<EmpAddress> addressList { get; set; }

        public DbSet<EmployeesSet> employeesSetList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpDetails>();
            modelBuilder.Entity<EmpBankDetails>();
            modelBuilder.Entity<EmpAddress>();
            modelBuilder.Entity<EmployeesSet>();


        }
    }
}