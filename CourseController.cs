using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Web.ViewModels;
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Web.Controllers.Admin
{
    [Authorize(Roles = "Manager")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var courses = _courseService.GetAllCourses();
            return View("CourseIndex", courses);
        }

        [HttpPost]
        public IActionResult Add(CourseViewModel model)
        {
            var course = new Course { Name = model.Name, TeacherId = model.TeacherId };
            _courseService.AddCourse(course);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveStudent(int courseId, int studentId)
        {
            _courseService.RemoveStudentFromCourse(courseId, studentId);
            return RedirectToAction("Index");
        }
    }
}
