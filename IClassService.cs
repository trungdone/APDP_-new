using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Services
{
    public interface IClassService
    {
        Class GetClassById(int id);
        void AddClass(Class classEntity);
        List<Class> GetAllClasses();
        void UpdateClass(Class classEntity);
        void RemoveStudentFromClass(int classId, int studentId);
        void DeleteClass(int classId);
        List<Class> GetClassesByCourseId(int courseId);
        List<Class> GetClassesByTeacherId(int teacherId);
    }
}
