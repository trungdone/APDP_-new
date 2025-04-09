using SIMS_Project.SIMS.Core.Enums;
using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Core.Models;
using SIMS_Project.SIMS.Core.Interfaces.Repositories;

namespace SIMS_Project.SIMS.Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public void MarkAttendance(int studentId, int classId, DateTime date, AttendanceStatus status)
        {
            var record = new AttendanceRecord
            {
                StudentId = studentId,
                ClassId = classId,
                Date = date,
                Status = status
            };
            _attendanceRepository.Add(record);
        }

        public List<AttendanceRecord> GetAttendanceByCourse(int courseId)
        {
            return _attendanceRepository.GetByCourse(courseId);
        }

        public List<AttendanceRecord> GetAttendanceByClassId(int classId)
        {
            return _attendanceRepository.GetByClassId(classId);
        }

        public void UpdateAttendance(AttendanceRecord attendance)
        {
            _attendanceRepository.Update(attendance);
        }

        public void DeleteAttendance(int attendanceId)
        {
            _attendanceRepository.Delete(attendanceId);
        }
    }
}