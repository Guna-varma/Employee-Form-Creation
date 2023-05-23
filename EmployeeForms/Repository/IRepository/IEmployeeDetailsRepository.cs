using EmployeeForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForms.Repository.IRepository
{
    public interface IEmployeeDetailsRepository : IRepository<EmpDetails>
    {
        void Update(EmpDetails employeeDetails);
    }
}
