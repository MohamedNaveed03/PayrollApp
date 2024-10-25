﻿using System;
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
         
                    decimal hourlyWage = _context.JobTitles.Find(employee.JobTitleId).Salary;
                    int yearsWorked = employee.YearsWorked;
                    decimal currentWage = hourlyWage * (decimal)Math.Pow(1.1, yearsWorked - 1);
                    decimal totalSalary = currentWage * payroll.TotalHoursWorked;
                    decimal basic = totalSalary * 0.64M;
                    decimal housing = totalSalary * 0.24M;
                    decimal transport = totalSalary * 0.12M;

                 
                    decimal tax = 0;
                    if (basic > 1000)
                    {
                        tax = (basic - 1000) * 0.30M;
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
