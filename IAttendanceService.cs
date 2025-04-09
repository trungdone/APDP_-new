using SIMS_Project.SIMS.Core.Enums;
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Services
{
    public interface IAttendanceService
    {

        void MarkAttendance(int studentId, int courseId, DateTime date, AttendanceStatus status);
        List<AttendanceRecord> GetAttendanceByCourse(int courseId);
        List<AttendanceRecord> GetAttendanceByClassId(int classId);

        void UpdateAttendance(AttendanceRecord attendance);
        void DeleteAttendance(int attendanceId);
    }
}
