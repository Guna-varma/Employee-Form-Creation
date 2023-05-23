using EmployeeForms.Models;
using EmployeeForms.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForms.Repository
{
    public class EmployeeDetailsRepository : Repository<EmpDetails>, IEmployeeDetailsRepository
    {
        public ApplicationDbContext _db;

        public EmployeeDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EmpDetails employeeDetails)
        {
            throw new NotImplementedException();
        }
    }
}
