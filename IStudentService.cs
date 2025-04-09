using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Services
{
    public interface IStudentService
    {
        Student GetStudentInfo(int studentId);
        List<Grade> GetStudentGrades(int studentId);
        List<Class> GetStudentSchedule(int studentId);

        List<Course> SearchCourses(string keyword);
        List<Class> SearchClasses(string keyword);
    }
}