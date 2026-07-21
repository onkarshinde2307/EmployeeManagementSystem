using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Filters
{
    // Session Authorization Filter
    // IMP :
    // Login nasel tar Login page var redirect karel

    public class SessionAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["UserId"] != null)
            {
                return true;
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result =
                new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        { "controller","Login"},
                        { "action","Index"}
                    });
        }
    }
}