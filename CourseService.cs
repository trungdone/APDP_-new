using SIMS_Project.SIMS.Core.Interfaces.Repositories;
using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Course GetCourseById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public List<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }

        public void AddCourse(Course course)
        {
            _courseRepository.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }

        public void DeleteCourse(int courseId)
        {
            _courseRepository.Delete(courseId);
        }

        public List<Course> SearchCourses(string keyword)
        {
            var courses = _courseRepository.GetAll();
            return courses.Where(c => c.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                     c.Major.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                     c.Lecturer.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                         .ToList();
        }

        public void RemoveStudentFromCourse(int courseId, int studentId)
        {
            var course = _courseRepository.GetById(courseId);
            if (course != null && course.StudentIds.Contains(studentId))
            {
                course.StudentIds.Remove(studentId);
                _courseRepository.Update(course);
            }
        }
    }
}