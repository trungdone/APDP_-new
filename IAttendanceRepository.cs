// File: SIMS.Core/Interfaces/Repositories/IAttendanceRepository.cs
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Repositories
{
    public interface IAttendanceRepository
    {
        AttendanceRecord GetById(int id);
        List<AttendanceRecord> GetAll();
        List<AttendanceRecord> GetByCourse(int courseId);
        List<AttendanceRecord> GetByClassId(int classId);
        void Add(AttendanceRecord attendance);
        void Update(AttendanceRecord attendance);
        void Delete(int attendanceId);
    }
}
