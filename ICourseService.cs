using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Services
{
    public interface ICourseService
    {
        Course GetCourseById(int id);
        void AddCourse(Course course);
        List<Course> GetAllCourses();
        void UpdateCourse(Course course);
        void DeleteCourse(int courseId);
        void RemoveStudentFromCourse(int courseId, int studentId);
        List<Course> SearchCourses(string keyword);
    }
}
