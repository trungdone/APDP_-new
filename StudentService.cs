using SIMS_Project.SIMS.Core.Interfaces.Repositories;
using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IClassRepository _classRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ICourseService _courseService;

        public StudentService(
            IUserRepository userRepository,
            IGradeRepository gradeRepository,
            IClassRepository classRepository,
            IAttendanceRepository attendanceRepository,
            ICourseService courseService)
        {
            _userRepository = userRepository;
            _gradeRepository = gradeRepository;
            _classRepository = classRepository;
            _attendanceRepository = attendanceRepository;
            _courseService = courseService;
        }

        public Student GetStudentInfo(int studentId)
        {
            var user = _userRepository.GetById(studentId);
            if (user is Student student)
                return student;
            throw new InvalidOperationException("User is not a student.");
        }

        public List<Grade> GetStudentGrades(int studentId)
        {
            return _gradeRepository.GetByStudentId(studentId);
        }

        public List<Class> GetStudentSchedule(int studentId)
        {
            var classes = _classRepository.GetAll();
            return classes.Where(c => c.StudentIds.Contains(studentId)).ToList();
        }


        public List<Course> SearchCourses(string keyword)
        {
            return _courseService.SearchCourses(keyword);
        }

        public List<Class> SearchClasses(string keyword)
        {
            var classes = _classRepository.GetAll();
            return classes.Where(c => c.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}