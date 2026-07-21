using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository
{
    // Interface : ILoginRepository
    // Purpose   : User Login

    public interface ILoginRepository
    {
        User Login(string email, string password);
    }
}