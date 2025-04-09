using Microsoft.AspNetCore.Mvc;
using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Core.Models;
using SIMS_Project.SIMS.Web.Services;

namespace SIMS_Project.SIMS.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IClassService _classService;
        private readonly ICourseService _courseService;
        private readonly CurrentUserService _currentUserService;

        public TeacherController(
            ITeacherService teacherService,
            IClassService classService,
            ICourseService courseService,
            CurrentUserService currentUserService)
        {
            _teacherService = teacherService;
            _classService = classService;
            _courseService = courseService;
            _currentUserService = currentUserService;
        }

        // Trang chính của giáo viên
        public IActionResult Index()
        {
            var teacherId = _currentUserService.GetCurrentUserId(); // Dòng 30
            var classes = _classService.GetClassesByTeacherId(teacherId);
            return View(classes);
        }

        // Xem danh sách điểm theo khóa học
        public IActionResult ViewGrades(int courseId)
        {
            var grades = _teacherService.GetGradesByCourseId(courseId);
            ViewBag.Course = _courseService.GetCourseById(courseId);
            return View(grades);
        }

        // Thêm điểm
        [HttpGet]
        public IActionResult AddGrade(int courseId)
        {
            ViewBag.CourseId = courseId;
            return View(new Grade());
        }

        [HttpPost]
        public IActionResult AddGrade(Grade grade)
        {
            if (ModelState.IsValid)
            {
                _teacherService.AddGrade(grade);
                return RedirectToAction("ViewGrades", new { courseId = grade.CourseId });
            }
            return View(grade);
        }

        // Sửa điểm
        [HttpGet]
        public IActionResult EditGrade(int id)
        {
            var grade = _teacherService.GetGradesByCourseId(0).FirstOrDefault(g => g.Id == id);
            if (grade == null)
                return NotFound();
            return View(grade);
        }

        [HttpPost]
        public IActionResult EditGrade(Grade grade)
        {
            if (ModelState.IsValid)
            {
                _teacherService.UpdateGrade(grade);
                return RedirectToAction("ViewGrades", new { courseId = grade.CourseId });
            }
            return View(grade);
        }

        // Xóa điểm
        public IActionResult DeleteGrade(int id, int courseId)
        {
            _teacherService.DeleteGrade(id);
            return RedirectToAction("ViewGrades", new { courseId });
        }

        // Xem danh sách điểm danh theo lớp
        public IActionResult ViewAttendance(int classId)
        {
            var attendances = _teacherService.GetAttendanceByClassId(classId);
            ViewBag.Class = _classService.GetClassById(classId);
            return View(attendances);
        }

        // Đánh dấu điểm danh
        [HttpGet]
        public IActionResult MarkAttendance(int classId)
        {
            ViewBag.ClassId = classId;
            return View(new AttendanceRecord()); // Sửa Attendance thành AttendanceRecord
        }

        [HttpPost]
        public IActionResult MarkAttendance(AttendanceRecord attendance) // Sửa Attendance thành AttendanceRecord
        {
            if (ModelState.IsValid)
            {
                _teacherService.MarkAttendance(attendance);
                return RedirectToAction("ViewAttendance", new { classId = attendance.ClassId });
            }
            return View(attendance);
        }

        // Sửa điểm danh
        [HttpGet]
        public IActionResult EditAttendance(int id)
        {
            var attendance = _teacherService.GetAttendanceByClassId(0).FirstOrDefault(a => a.Id == id);
            if (attendance == null)
                return NotFound();
            return View(attendance);
        }

        [HttpPost]
        public IActionResult EditAttendance(AttendanceRecord attendance) // Sửa Attendance thành AttendanceRecord
        {
            if (ModelState.IsValid)
            {
                _teacherService.UpdateAttendance(attendance);
                return RedirectToAction("ViewAttendance", new { classId = attendance.ClassId });
            }
            return View(attendance);
        }

        // Xóa điểm danh
        public IActionResult DeleteAttendance(int id, int classId)
        {
            _teacherService.DeleteAttendance(id);
            return RedirectToAction("ViewAttendance", new { classId });
        }
    }
}