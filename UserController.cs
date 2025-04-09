using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIMS_Project.SIMS.Core.Interfaces.Services;

namespace SIMS_Project.SIMS.Web.Controllers.Admin
{
    [Authorize(Roles = "Manager")] // Chỉ Admin truy cập
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService; // DIP
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View("UserIndex", users);
        }

        [HttpPost]
        public IActionResult RemoveFromCourse(int userId, int courseId)
        {
            _userService.RemoveUserFromCourse(userId, courseId);
            return RedirectToAction("Index");
        }
    }
}
