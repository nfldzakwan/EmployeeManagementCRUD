using Microsoft.AspNetCore.Mvc;
using EmployeeManagementCRUD.Data;
using EmployeeManagementCRUD.Models;
using System.Linq;

namespace EmployeeManagementCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // DASHBOARD
        public IActionResult Dashboard(string searchString)
        {
            var employees = from e in _context.Employees
                            select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e =>
                e.Name.Contains(searchString) ||
                e.EmployeeNumber.Contains(searchString) ||
                e.Position.Contains(searchString));
            }
            return View(employees.ToList());

        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
   
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }
           return View(employee);
        }

        //EDIT
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(employee);
        }

        //DELETE
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }
    }
}

