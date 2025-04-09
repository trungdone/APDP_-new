using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;
        private readonly IClassService _classService;
        private readonly IAttendanceService _attendanceService;

        public AdminService(
            IUserService userService,
            ICourseService courseService,
            IClassService classService,
            IAttendanceService attendanceService)
        {
            _userService = userService;
            _courseService = courseService;
            _classService = classService;
            _attendanceService = attendanceService;
        }

        // User Management
        public void AddUser(User user, string verificationCode = null)
        {
            _userService.Register(user, verificationCode);
        }

        public void UpdateUser(User user)
        {
            _userService.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
        }

        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        // Course Management
        public void AddCourse(Course course)
        {
            _courseService.AddCourse(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseService.UpdateCourse(course);
        }

        public void DeleteCourse(int courseId)
        {
            _courseService.DeleteCourse(courseId);
        }

        public List<Course> GetAllCourses()
        {
            return _courseService.GetAllCourses();
        }

        // Class Management
        public void AddClass(Class classEntity)
        {
            _classService.AddClass(classEntity);
        }

        public void UpdateClass(Class classEntity)
        {
            _classService.UpdateClass(classEntity);
        }

        public void DeleteClass(int classId)
        {
            _classService.DeleteClass(classId);
        }

        public List<Class> GetAllClasses()
        {
            return _classService.GetAllClasses();
        }

        // Attendance Management
        public void MarkAttendance(AttendanceRecord attendance)
        {
            _attendanceService.MarkAttendance(attendance.StudentId, attendance.ClassId, attendance.Date, attendance.Status);
        }

        public void UpdateAttendance(AttendanceRecord attendance)
        {
            _attendanceService.UpdateAttendance(attendance);
        }

        public void DeleteAttendance(int attendanceId)
        {
            _attendanceService.DeleteAttendance(attendanceId);
        }

        public List<AttendanceRecord> GetAttendanceByCourse(int courseId)
        {
            return _attendanceService.GetAttendanceByCourse(courseId);
        }

        public List<AttendanceRecord> GetAttendanceByClassId(int classId)
        {
            return _attendanceService.GetAttendanceByClassId(classId);
        }
    }
}