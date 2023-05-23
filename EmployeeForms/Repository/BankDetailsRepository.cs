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
    public class BankDetailsRepository : Repository<EmpBankDetails>, IBankDetailsRepository
    {
        public ApplicationDbContext _db;

        public BankDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EmpBankDetails bankDetails)
        {
            throw new NotImplementedException();
        }
    }
}
