using EmployeeManagementSystem.Filters;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;
using System;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    // Controller : EmployeeController
    // Purpose    : Employee CRUD Operations

    [SessionAuthorize]
    public class EmployeeController : Controller
    {
        // Repository Object
        // IMP : Database operations through Repository Pattern

        private readonly IEmployeeRepository repository = new EmployeeRepository();

        // Employee List
        // URL : /Employee/Index

        public ActionResult Index(string search, string sortOrder, int? page)
        {
            // Current Search
            ViewBag.CurrentSearch = search;

            // Sorting
            ViewBag.NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SalarySort = sortOrder == "salary" ? "salary_desc" : "salary";

            // Get Employees
            var employees = repository.GetEmployees(search, sortOrder, page);

            return View(employees);
        }

        // GET : Create Employee

        public ActionResult Create()
        {
            return View();
        }

        // POST : Create Employee

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            try
            {
                employee.CreatedDate = DateTime.Now;

                repository.Add(employee);

                TempData["Success"] = "Employee Added Successfully.";

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong.";

                return View(employee);
            }
        }

        // GET : Edit Employee

        public ActionResult Edit(int id)
        {
            Employee employee = repository.GetById(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        // POST : Edit Employee

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            try
            {
                repository.Update(employee);

                TempData["Success"] = "Employee Updated Successfully.";

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong.";

                return View(employee);
            }
        }
        // Employee Details

        public ActionResult Details(int id)
        {
            Employee employee = repository.GetById(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        // GET : Delete Employee

        public ActionResult Delete(int id)
        {
            Employee employee = repository.GetById(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        // POST : Delete Employee

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                repository.Delete(id);

                TempData["Success"] = "Employee Deleted Successfully.";

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to delete employee.";

                return RedirectToAction("Index");
            }
        }
    }
}