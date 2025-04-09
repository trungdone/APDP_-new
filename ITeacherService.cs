using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Services
{
    public interface ITeacherService
    {
        void AddGrade(Grade grade);
        void UpdateGrade(Grade grade);
        void DeleteGrade(int gradeId);
        void MarkAttendance(AttendanceRecord attendance); 
        void UpdateAttendance(AttendanceRecord attendance);
        void DeleteAttendance(int attendanceId);
        List<Grade> GetGradesByCourseId(int courseId);
        List<AttendanceRecord> GetAttendanceByClassId(int classId);
    }
}