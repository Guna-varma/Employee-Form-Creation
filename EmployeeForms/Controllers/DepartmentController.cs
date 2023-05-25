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

        public DepartmentController(IUnitOfWork categoryRepository)
        {
            repo = categoryRepository;
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Upsert as create
                return Create();
            }

            Department deptFromDb = repo.departmentSet.Get(u => u.Id == id);
            if (deptFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }

            // Upsert as edit
            return Edit(deptFromDb);
        }

        [HttpPost]
        public IActionResult Upsert(Department department)
        {
            if (ModelState.IsValid) // validations
            {
                if (department.Id <= 0)
                {
                    // Insert
                    repo.departmentSet.Add(department);
                    TempData["success"] = "Form Created Successfully!";
                }
                else
                {
                    // Update
                    repo.departmentSet.Update(department);
                    TempData["success"] = "Form Updated Successfully!";
                }

                repo.Save(); // save

                return RedirectToAction("Index"); // redirect to the index page
            }

            // Invalid model state, return to the upsert view with validation errors
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {

            if (ModelState.IsValid) //validations
            {
                repo.departmentSet.Add(department); // add category 
                repo.Save(); //save
                TempData["success"] = "Form Created Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            Department deptFromDb = repo.departmentSet.Get(u => u.Id == id);
            if (deptFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(deptFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid) //validations
            {
                repo.departmentSet.Update(department);// add category 
                repo.Save(); //save
                TempData["success"] = "Form Updated Successfully!";

                return RedirectToAction("Index"); // add the data into db
            }
            return View();
        }



        /*   [HttpPost, ActionName("Delete")]
           public IActionResult DeletePost(int? id)
           {
               Department? obj = repo.departmentSet.Get(u => u.Id == id);
               if (obj == null)
               {
                   return NotFound("Id:" + id + ", is not Found");
               }
               repo.departmentSet.Remove(obj);
               repo.Save();  //save
               TempData["success"] = "form Deleted Successfully!";

               return RedirectToAction("Index");
           } */

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
