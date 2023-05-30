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
        private readonly IWebHostEnvironment env;

        public EmployeesSetController(IUnitOfWork categoryRepository, IWebHostEnvironment environment)
        {
            repo = categoryRepository;
            env = environment;
        }

        public IActionResult Upsert(int? id)  // combining of 'Update' and 'Insert'.
        {
            EmpSetDetailsVm empDetailsVM = new()
            {
                DeptList = repo.departmentSet.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DeptName,
                    Value = u.Id.ToString()
                }),
                EmployeesSet = new EmployeesSet()
            };
            if (id == null || id == 0)
            {
                //create
                return View(empDetailsVM);
            }
            else
            {
                //update
                empDetailsVM.EmployeesSet = repo.employeesSet.Get(u => u.Id == id);
                return View(empDetailsVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(EmpSetDetailsVm empDetailsVM, IFormFile? file)
        {
            if (ModelState.IsValid) //validations
            {
                string wweRootPath = env.WebRootPath;
                if (file != null)
                {
                    // File type validation
                    string[] allowedExtensions = { ".png", ".jpg", ".jpeg" };
                    string fileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("File", "Only .png, .jpeg and .jpg files are allowed.");
                        empDetailsVM.DeptList = repo.departmentSet.GetAll().Select(u => new SelectListItem
                        {
                            Text = u.DeptName,
                            Value = u.Id.ToString()
                        });
                        return View(empDetailsVM);
                    }

                    // File size validation
                    long maxFileSize = 2 * 1024 * 1024; // 2MB
                    if (file.Length > maxFileSize)
                    {
                        ModelState.AddModelError("File", "File size must be less than 2MB.");
                        empDetailsVM.DeptList = repo.departmentSet.GetAll().Select(u => new SelectListItem
                        {
                            Text = u.DeptName,
                            Value = u.Id.ToString()
                        });
                        return View(empDetailsVM);
                    }

                    string fileName = Guid.NewGuid().ToString() + fileExtension;

                    string empFilePath = Path.Combine(wweRootPath, @"images\employeeDetails\");

                    if (!string.IsNullOrEmpty(empDetailsVM.EmployeesSet.ImageURL))
                    {
                        //delete old image path
                        var oldImagePath =
                            Path.Combine(wweRootPath, empDetailsVM.EmployeesSet.ImageURL.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(empFilePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    empDetailsVM.EmployeesSet.ImageURL = @"\images\employeeDetails\" + fileName;
                }

                if (empDetailsVM.EmployeesSet.Id == null || empDetailsVM.EmployeesSet.Id == 0)
                {
                    repo.employeesSet.Add(empDetailsVM.EmployeesSet); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Form Created Successfully!";
                }
                else
                {
                    repo.employeesSet.Update(empDetailsVM.EmployeesSet); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Form Updated Successfully!";
                }

                return RedirectToAction("Index"); // add the data into db
            }
            else
            {
                empDetailsVM.DeptList = repo.departmentSet.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DeptName,
                    Value = u.Id.ToString()
                });
                return View(empDetailsVM);
            }
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

