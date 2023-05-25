using EmployeeForms.Models;

namespace EmployeeForms.Repository.IRepository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        void Update(Department departmentDetails);
    }
}
