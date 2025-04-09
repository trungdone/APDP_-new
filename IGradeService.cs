using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Services
{
    public interface IGradeService
    {
        Grade GetGradeById(int id);
        List<Grade> GetGradesByStudentId(int studentId);
        List<Grade> GetGradesByCourseId(int courseId);
        void AddGrade(Grade grade);
        void UpdateGrade(Grade grade);
        void DeleteGrade(int gradeId);
    }
}
