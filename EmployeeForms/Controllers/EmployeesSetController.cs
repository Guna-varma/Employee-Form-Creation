using EmployeeForms.Models;
using EmployeeForms.Repository.IRepository;
using EmployeeForms.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeForms.Controllers
{
    public class EmployeesSetController : Controller
    {

        private readonly IUnitOfWork repo;

        public EmployeesSetController(IUnitOfWork categoryRepository)
        {
            repo = categoryRepository;
        }
        
        public IActionResult Index()
        {
            List<EmployeesSet> employeesSets = repo.employeesSet.GetAll(includeProperties:"Department").ToList();
            return View(employeesSets);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<EmployeesSet> employeesList = repo.employeesSet.GetAll(includeProperties: "Department").ToList();

            return Json(new { data = employeesList });
        }

        public IActionResult Create()
        {
            EmpSetDetailsVm empVm = new()
            {
                DeptList = repo.departmentSet.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DeptName,
                    Value = u.Id.ToString()
                }),
                EmployeesSet = new EmployeesSet()
            };
            return View(empVm);
        }

        [HttpPost]
        public IActionResult Create(EmpSetDetailsVm empVm)
        {
            if (ModelState.IsValid) //validations
            {
                repo.employeesSet.Add(empVm.EmployeesSet); // add emp 
                repo.Save(); //save
                TempData["success"] = "Form Created Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            else
            {
                empVm.DeptList = repo.departmentSet.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DeptName,
                    Value = u.Id.ToString()
                });
                return View(empVm);
            }
        }

        public IActionResult Edit(int? id)
        {
            EmpSetDetailsVm empSetEditVm = new()
            {
                DeptList = repo.departmentSet.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DeptName,
                    Value = u.Id.ToString()
                }),
                EmployeesSet = new EmployeesSet()
            };

            empSetEditVm.EmployeesSet = repo.employeesSet.Get(u => u.Id == id);
            return View(empSetEditVm);
        }

        [HttpPost]
        public IActionResult Edit(EmpSetDetailsVm empEditVm)
        {
            if (ModelState.IsValid) //validations
            {
                repo.employeesSet.Update(empEditVm.EmployeesSet); // edit Employee 
                repo.Save(); //save
                TempData["success"] = "Form Updated Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            else
            {
                empEditVm.DeptList = repo.departmentSet.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DeptName,
                    Value = u.Id.ToString()
                });
                return View(empEditVm);
            }
        }

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null | id <= 0)
        //    {
        //        return NotFound("No Id is found");
        //    }
        //    EmployeesSet empFromDb = repo.employeesSet.Get(u => u.Id == id);
        //    if (empFromDb == null)
        //    {
        //        return NotFound("id: " + id + ", is not found!");
        //    }
        //    return View(empFromDb);
        //}

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var employeeToBeDeleted = repo.employeesSet.Get(u => u.Id == id);
            if (employeeToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.employeesSet.Remove(employeeToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });
        }

    }
}

