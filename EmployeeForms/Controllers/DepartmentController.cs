using EmployeeForms.Models;
using EmployeeForms.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;

namespace EmployeeForms.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork repo;

        private readonly IWebHostEnvironment env;

        public DepartmentController(IUnitOfWork departmentRepository)
        {
            repo = departmentRepository;
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new Department());
            }

            Department department = repo.departmentSet.Get(u => u.Id == id);

            if (department == null)
            {
                return NotFound("Department with id: " + id + " is not found!");
            }

            if (department == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(department);
        }

        [HttpPost]
        public IActionResult Upsert(Department department)
        {
            if (ModelState.IsValid)
            {
                if (department.Id > 0)
                {
                    repo.departmentSet.Update(department);
                    TempData["success"] = "Form Updated Successfully!";
                }
                else
                {
                    repo.departmentSet.Add(department);
                    TempData["success"] = "Form Created Successfully!";
                }

                repo.Save();
                return RedirectToAction("Index");
            }

            return View(department);
        }


        public IActionResult Index()
        {
            List<Department> Departments = repo.departmentSet.GetAll().ToList();
            return View(Departments);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department> departmentList = repo.departmentSet.GetAll().ToList();

            return Json(new { data = departmentList });
        }

        public IActionResult Remove(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            Department empFromDb = repo.departmentSet.Get(u => u.Id == id);
            if (empFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(empFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var deptToBeDeleted = repo.departmentSet.Get(u => u.Id == id);
            if (deptToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.departmentSet.Remove(deptToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });
        }
    }
}
