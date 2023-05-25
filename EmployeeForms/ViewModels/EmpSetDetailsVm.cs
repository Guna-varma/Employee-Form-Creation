using EmployeeForms.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeForms.ViewModels
{
    public class EmpSetDetailsVm
    {
        public EmployeesSet EmployeesSet { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> DeptList { get; set; }
    }
}
