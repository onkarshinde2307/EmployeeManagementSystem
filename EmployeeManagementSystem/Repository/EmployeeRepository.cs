using EmployeeManagementSystem.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBEntities db = new EmployeeDBEntities();

        public IPagedList<Employee> GetEmployees(string search, string sortOrder, int? page)
        {
            var employees = db.Employees.AsQueryable();

            // Search

            if (!string.IsNullOrEmpty(search))
            {
                employees = employees.Where(x =>
                        x.Name.Contains(search) ||
                        x.Department.Contains(search) ||
                        x.City.Contains(search));
            }

            // Sorting

            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(x => x.Name);
                    break;

                case "":
                    employees = employees.OrderBy(x => x.Name);
                    break;

                case "salary":
                    employees = employees.OrderBy(x => x.Salary);
                    break;

                case "salary_desc":
                    employees = employees.OrderByDescending(x => x.Salary);
                    break;

                default:
                    employees = employees.OrderBy(x => x.Id);   // Default by Id
                    break;
            }

            int pageSize = 5;
            int pageNumber = page ?? 1;

            return employees.ToPagedList(pageNumber, pageSize);
        }

        public Employee GetById(int id)
        {
            return db.Employees.Find(id);
        }

        public void Add(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void Update(Employee employee)
        {
            db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee emp = db.Employees.Find(id);

            if (emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
        }

        public List<Employee> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}