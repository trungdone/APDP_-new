using Microsoft.AspNetCore.Mvc;

namespace SIMS_Project.SIMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Login successful!"); // Trả về text đơn giản
        }
    }
}
