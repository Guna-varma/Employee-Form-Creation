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
    public class AddressDetailsRepository : Repository<EmpAddress>, IAddressRepository
    {
        public ApplicationDbContext _db;

        public AddressDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EmpAddress addressDetails)
        {
            throw new NotImplementedException();
        }
    }
}
