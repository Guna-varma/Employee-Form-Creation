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

        public IEmployeesSetRepository employeesSet { get; set; }
        public IDepartmentRepository departmentSet { get; set; }

        //public IEmployeesSetRepository employeesSet => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            employeesSet = new EmployeesSetRepository(_db);
            departmentSet = new DepartmentRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
