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
    public class EmployeesSetRepository : Repository<EmployeesSet>, IEmployeesSetRepository
    {
        public ApplicationDbContext _db;

        public EmployeesSetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EmployeesSet employeesSetDetails)
        {
            _db.employeesSetList.Update(employeesSetDetails);
        }
    }
}
