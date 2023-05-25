using EmployeeForms.Models;
using EmployeeForms.Repository.IRepository;

namespace EmployeeForms.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public ApplicationDbContext _db;

        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Department departmentDetails)
        {
            _db.departmentList.Update(departmentDetails);
        }
    }
}
