using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Repositories
{
    public interface IGradeRepository
    {
        Grade GetById(int id);
        List<Grade> GetAll();
        List<Grade> GetByStudentId(int studentId);
        List<Grade> GetByCourseId(int courseId);
        void Add(Grade grade);
        void Update(Grade grade);
        void Delete(int gradeId);
    }
}