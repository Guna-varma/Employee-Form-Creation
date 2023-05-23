using EmployeeForms.Models;
using EmployeeForms.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

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
            List<EmployeesSet> employeesSets = repo.employeesSet.GetAll().ToList();
            return View(employeesSets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeesSet employeesSet)
        { 

            if (ModelState.IsValid) //validations
            {
                repo.employeesSet.Add(employeesSet); // add category 
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
            EmployeesSet employeesFromDb = repo.employeesSet.Get(u => u.Id == id);
            if (employeesFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(employeesFromDb);
        }

        [HttpPost]
        public IActionResult Edit(EmployeesSet employeesSet)
        {
            if (ModelState.IsValid) //validations
            {
                repo.employeesSet.Update(employeesSet);// add category 
                repo.Save(); //save
                TempData["success"] = "Form Updated Successfully!";

                return RedirectToAction("Index"); // add the data into db
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            EmployeesSet empFromDb = repo.employeesSet.Get(u => u.Id == id);
            if (empFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(empFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            EmployeesSet? obj = repo.employeesSet.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound("Id:" + id + ", is not Found");
            }
            repo.employeesSet.Remove(obj);
            repo.Save();  //save
            TempData["success"] = "form Deleted Successfully!";

            return RedirectToAction("Index");
        }
    }
}

