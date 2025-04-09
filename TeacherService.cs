using SIMS_Project.SIMS.Core.Interfaces.Repositories;
using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IAttendanceRepository _attendanceRepository;

        public TeacherService(
            IGradeRepository gradeRepository,
            IAttendanceRepository attendanceRepository)
        {
            _gradeRepository = gradeRepository;
            _attendanceRepository = attendanceRepository;
        }

        public void AddGrade(Grade grade)
        {
            _gradeRepository.Add(grade);
        }

        public void UpdateGrade(Grade grade)
        {
            _gradeRepository.Update(grade);
        }

        public void DeleteGrade(int gradeId)
        {
            _gradeRepository.Delete(gradeId);
        }

        public void MarkAttendance(AttendanceRecord attendance) // Sửa Attendance thành AttendanceRecord
        {
            attendance.Date = DateTime.Now;
            _attendanceRepository.Add(attendance);
        }

        public void UpdateAttendance(AttendanceRecord attendance) // Sửa Attendance thành AttendanceRecord
        {
            _attendanceRepository.Update(attendance);
        }

        public void DeleteAttendance(int attendanceId)
        {
            _attendanceRepository.Delete(attendanceId);
        }

        public List<Grade> GetGradesByCourseId(int courseId)
        {
            return _gradeRepository.GetByCourseId(courseId);
        }

        public List<AttendanceRecord> GetAttendanceByClassId(int classId) 
        {
            return _attendanceRepository.GetByClassId(classId);
        }
    }
}