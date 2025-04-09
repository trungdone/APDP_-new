// File: SIMS.Infrastructure/Data/Repositories/CsvAttendanceRepository.cs
using SIMS_Project.SIMS.Core.Interfaces.Repositories;
using SIMS_Project.SIMS.Core.Models;
using SIMS_Project.SIMS.Infrastructure.Data.Contexts;
using System.Linq;

namespace SIMS_Project.SIMS.Infrastructure.Data.Repositories
{
    public class CsvAttendanceRepository : IAttendanceRepository
    {
        private readonly CsvDataContext _context;

        public CsvAttendanceRepository(CsvDataContext context)
        {
            _context = context;
        }

        public AttendanceRecord GetById(int id)
        {
            var attendances = _context.Read<AttendanceRecord>("attendances.csv");
            return attendances.FirstOrDefault(a => a.Id == id);
        }

        public List<AttendanceRecord> GetByClassId(int classId)
        {
            var attendances = _context.Read<AttendanceRecord>("attendances.csv");
            return attendances.Where(a => a.ClassId == classId).ToList();
        }

        public List<AttendanceRecord> GetAll()
        {
            return _context.Read<AttendanceRecord>("attendances.csv");
        }

        public List<AttendanceRecord> GetByCourse(int courseId)
        {
            // Đọc tất cả các bản ghi điểm danh
            var attendances = _context.Read<AttendanceRecord>("attendances.csv");

            // Lọc các bản ghi điểm danh theo courseId
            // (Cần liên kết với Class để biết Class nào thuộc Course nào)
            var classes = _context.Read<Class>("classes.csv");
            var classIds = classes.Where(c => c.CourseId == courseId).Select(c => c.Id).ToList();

            return attendances.Where(a => classIds.Contains(a.ClassId)).ToList();
        }

        public void Add(AttendanceRecord attendance)
        {
            var attendances = _context.Read<AttendanceRecord>("attendances.csv");
            attendance.Id = attendances.Any() ? attendances.Max(a => a.Id) + 1 : 1;
            attendances.Add(attendance);
            _context.Write("attendances.csv", attendances);
        }

        public void Update(AttendanceRecord attendance)
        {
            var attendances = _context.Read<AttendanceRecord>("attendances.csv");
            var existing = attendances.FirstOrDefault(a => a.Id == attendance.Id);
            if (existing != null)
            {
                attendances.Remove(existing);
                attendances.Add(attendance);
                _context.Write("attendances.csv", attendances);
            }
        }

        public void Delete(int attendanceId)
        {
            var attendances = _context.Read<AttendanceRecord>("attendances.csv");
            var attendance = attendances.FirstOrDefault(a => a.Id == attendanceId);
            if (attendance != null)
            {
                attendances.Remove(attendance);
                _context.Write("attendances.csv", attendances);
            }
        }
    }
}