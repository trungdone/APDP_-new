using Microsoft.AspNetCore.Mvc;
using SIMS_Project.SIMS.Core.Exceptions;
using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Web.Services;

namespace SIMS_Project.SIMS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly CurrentUserService _currentUserService;

        public AccountController(IUserService userService, CurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        public IActionResult Login()
        {
            try
            {
                return View("Login", new SIMS_Project.SIMS.Web.ViewModels.LoginViewModel());
            }
            catch (Exception ex)
            {
                return Content($"Error loading Login view: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Login(SIMS_Project.SIMS.Web.ViewModels.LoginViewModel model)
        {
            try
            {
                var user = _userService.Login(model.Email, model.Password, model.SelectedType);
                _currentUserService.SetCurrentUser(user);
                ViewBag.ClassId = user.ClassId;
                ViewBag.CourseId = user.CourseId;
                return RedirectToAction("Index", "Home");
            }
            catch (UserNotFoundException)
            {
                ModelState.AddModelError("", "Invalid login attempt");
                return View("Login", model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View("Login", model);
            }
        }
    }
}