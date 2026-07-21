using EmployeeManagementSystem.Models;
using System.Linq;

namespace EmployeeManagementSystem.Repository
{
    //====================================================
    // Login Repository
    // Purpose : Validate User
    //====================================================

    public class LoginRepository : ILoginRepository
    {
        private readonly EmployeeDBEntities db = new EmployeeDBEntities();

        public User Login(string email, string password)
        {
            return db.Users.FirstOrDefault(x =>
                    x.Email == email &&
                    x.Password == password);
        }
    }
}
