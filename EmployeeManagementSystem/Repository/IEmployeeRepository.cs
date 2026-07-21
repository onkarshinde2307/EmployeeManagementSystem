using EmployeeManagementSystem.Models;
using PagedList;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Repository
{
    // Interface : IEmployeeRepository
    // Purpose   : Employee CRUD Contract
    // IMP : Controller interface use karel.

    public interface IEmployeeRepository
    {
        // Get All Employees
        IPagedList<Employee> GetEmployees(string search, string sortOrder, int? page);


        // Get Employee By Id
        Employee GetById(int id);

        // Insert Employee
        void Add(Employee employee);

        // Update Employee
        void Update(Employee employee);

        // Delete Employee
        void Delete(int id);
    }
}