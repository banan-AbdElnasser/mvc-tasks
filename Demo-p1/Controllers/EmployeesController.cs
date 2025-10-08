using Demo.BLL.Interfaces;
using Demo.BLL.Repositiories;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_p1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var employee = _employeeRepository.GetAll();

            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public IActionResult Details(int? id, string ViewName = "")
        {
            if (id is null)
            {

                return BadRequest();
            }
            var Employee = _employeeRepository.GetById(id.Value);
            if (Employee is null)
            {
                return BadRequest();
            }
            return View(ViewName, Employee);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            return Details(id, "Edit");
        }
        [HttpPost]
        public IActionResult Edit(Employee Employee, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.Update(Employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(Employee);
        }
        public IActionResult Delete(int? id)
        {

            return Details(id, "Edit");
        }
        public IActionResult Delete(Employee Employee, [FromRoute] int id)
        {
            if (id != Employee.Id)
            {
                return BadRequest();
            }
            try
            {
                _employeeRepository.Delete(Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(Employee);
            }
        }
    }
}
