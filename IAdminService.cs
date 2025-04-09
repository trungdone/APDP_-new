using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Services
{
    public interface IAdminService
    {
        // User Management
        void AddUser(User user, string verificationCode = null);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        List<User> GetAllUsers();

        // Course Management
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int courseId);
        List<Course> GetAllCourses();

        // Class Management
        void AddClass(Class classEntity);
        void UpdateClass(Class classEntity);
        void DeleteClass(int classId);
        List<Class> GetAllClasses();

        // Attendance Management
        void MarkAttendance(AttendanceRecord attendance);
        void UpdateAttendance(AttendanceRecord attendance);
        void DeleteAttendance(int attendanceId);
        List<AttendanceRecord> GetAttendanceByCourse(int courseId);
        List<AttendanceRecord> GetAttendanceByClassId(int classId);
    }
}