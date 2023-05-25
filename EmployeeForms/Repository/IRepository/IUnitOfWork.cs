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
        IDepartmentRepository departmentSet { get; }
        IEmployeesSetRepository employeesSet { get; }

        void Save();
    }
}
