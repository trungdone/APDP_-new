using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIMS_Project.SIMS.Application.Services;
using SIMS_Project.SIMS.Core.Interfaces.Services;

namespace SIMS_Project.SIMS.Web.Controllers.Admin
{
    [Authorize(Roles = "Manager")]
    public class StudentController : Controller
    {
        private readonly IClassService _classService;
        private readonly IAttendanceService _attendanceService;

        public StudentController(IClassService classService, IAttendanceService attendanceService)
        {
            _classService = classService;
            _attendanceService = attendanceService;
        }

        public IActionResult Index()
        {
            var classes = _classService.GetAllClasses();
            return View(classes);
        }

        [HttpPost]
        public IActionResult RemoveFromClass(int classId, int studentId)
        {
            _classService.RemoveStudentFromClass(classId, studentId);
            return RedirectToAction("StudentIndex");
        }

        public IActionResult Attendance(int courseId)
        {
            var records = _attendanceService.GetAttendanceByCourse(courseId);
            return View("Attendance", records);
        }
    }
}
