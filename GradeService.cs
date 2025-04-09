using SIMS_Project.SIMS.Core.Interfaces.Repositories;
using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public Grade GetGradeById(int id)
        {
            return _gradeRepository.GetById(id);
        }

        public List<Grade> GetGradesByStudentId(int studentId)
        {
            return _gradeRepository.GetByStudentId(studentId);
        }

        public List<Grade> GetGradesByCourseId(int courseId)
        {
            return _gradeRepository.GetByCourseId(courseId);
        }

        public void AddGrade(Grade grade)
        {
            grade.Date = DateTime.Now;
            _gradeRepository.Add(grade);
        }

        public void UpdateGrade(Grade grade)
        {
            _gradeRepository.Update(grade);
        }

        public void DeleteGrade(int gradeId)
        {
            _gradeRepository.Delete(gradeId);
        }
    }
}