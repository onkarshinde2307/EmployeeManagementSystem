using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;
using EmployeeManagementSystem.ViewModels;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    // Controller : LoginController
    // Purpose    : Login / Logout

    public class LoginController : Controller
    {
        // Repository Object

        private readonly ILoginRepository repository = new LoginRepository();

        // Login Page
        // URL : /Login/Index

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Employee");
            }

            return View();
        }

        // Login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = repository.Login(model.Email, model.Password);

            if (user != null)
            {
                // Session Create

                Session["UserId"] = user.Id;
                Session["UserName"] = user.Name;
                Session["Email"] = user.Email;

                TempData["Success"] = "Welcome " + user.Name;

                return RedirectToAction("Index", "Employee");
            }

            ViewBag.Error = "Invalid Email or Password.";

            return View(model);
        }

        // Logout

        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            TempData["Success"] = "Logout Successfully.";

            return RedirectToAction("Index");
        }
    }
}