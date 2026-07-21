using System.Web.Mvc;

public class ErrorController : Controller
{
    public ActionResult Error404()
    {
        return View();
    }

    public ActionResult Error500()
    {
        return View();
    }
}