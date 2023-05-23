using EmployeeForms.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForms.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBankDetailsRepository bankDetails { get; }

        IEmployeeDetailsRepository employeeDetails { get; }
        IAddressRepository addressDetails { get; }

        IEmployeesSetRepository employeesSet { get; }

        void Save();
    }
}
