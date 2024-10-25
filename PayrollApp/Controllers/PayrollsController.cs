using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayrollApp.Data;

namespace PayrollApp.Controllers
{
    public class PayrollsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PayrollsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Payrolls
        public IActionResult Index()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: Payrolls/CalculatePayroll

        [HttpPost]
        public async Task<IActionResult> CalculatePayroll(Payroll payroll)
            
        {
            ModelState.Remove("Employee");
            if (ModelState.IsValid)
            {
                var employee = await _context.Employees.FindAsync(payroll.EmployeeId);
                if (employee != null)
                {

                    decimal hourlyWage = Math.Round(_context.JobTitles.Find(employee.JobTitleId).Salary, 2);
                    int yearsWorked = employee.YearsWorked;
                    decimal currentWage = Math.Round(hourlyWage * (decimal)Math.Pow(1.1, yearsWorked - 1), 2);
                    decimal totalSalary = Math.Round(currentWage * payroll.TotalHoursWorked, 2);
                    decimal basic = Math.Round(totalSalary * 0.64M, 2);
                    decimal housing = Math.Round(totalSalary * 0.24M, 2);
                    decimal transport = Math.Round(totalSalary * 0.12M, 2);


                    decimal tax = 0;
                    if (basic > 1000)
                    {
                        tax = Math.Round((basic - 1000) * 0.30M);
                    }

                    
                    ViewBag.Basic = basic;
                    ViewBag.Housing = housing;
                    ViewBag.Transport = transport;
                    ViewBag.Tax = tax;
                    ViewBag.TotalSalary = totalSalary;

                    return View("PayrollView");
                }
            }

            return View(payroll);
        }

    }
}
