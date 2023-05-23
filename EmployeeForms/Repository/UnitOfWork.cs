using EmployeeForms.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForms.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db;

        public IEmployeeDetailsRepository employeeDetails { get; set; }
        public IBankDetailsRepository bankDetails { get; set; }
        public IAddressRepository addressDetails { get; set; }
        public IEmployeesSetRepository employeesSet { get; set; }

        //public IEmployeesSetRepository employeesSet => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            employeeDetails = new EmployeeDetailsRepository(_db);

            bankDetails = new BankDetailsRepository(_db);

            addressDetails = new AddressDetailsRepository(_db);

            employeesSet = new EmployeesSetRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
