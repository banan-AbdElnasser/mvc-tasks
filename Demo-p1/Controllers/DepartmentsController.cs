using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_p1.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;   
        }   
            
            public IActionResult Index()
        {
            var department = _departmentRepository.GetAll();

            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( Department department)
        {
            if(ModelState.IsValid)
            {
                _departmentRepository.Add(department);
           return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        public IActionResult Details(int? id,string ViewName="")
        {
            if (id is null)
            {
                
                return BadRequest();
            }
            var department = _departmentRepository.GetById(id.Value);
            if(department is null)
            {
                return BadRequest();
            }
                return View(ViewName,department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (id is null)
            //{

            //    return BadRequest();
            //}
            //var department = _departmentRepository.GetById(id.Value);
            //if (department is null)
            //{
            //    return BadRequest();
            //}
            return Details(id,"Edit");
        }
        [HttpPost]
        public IActionResult Edit(Department department, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _departmentRepository.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch(System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(department);
        }
        public IActionResult Delete(int? id)
        {
  
            return Details(id, "Edit");
        }
        public IActionResult Delete( Department department, [FromRoute] int id)
        {
            if(id!=department.Id)
            {
                return BadRequest();
            }
            try
            {
                _departmentRepository.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch(System.Exception ex)
            {
                ModelState.AddModelError (string.Empty, ex.Message);
                return View(department);
            }
          
           
        }
    }
}
