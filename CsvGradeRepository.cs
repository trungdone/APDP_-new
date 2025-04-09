using SIMS_Project.SIMS.Core.Interfaces.Repositories;
using SIMS_Project.SIMS.Core.Models;
using SIMS_Project.SIMS.Infrastructure.Data.Contexts;

namespace SIMS_Project.SIMS.Infrastructure.Data.Repositories
{
    public class CsvGradeRepository : IGradeRepository
    {
        private readonly CsvDataContext _context;

        public CsvGradeRepository(CsvDataContext context)
        {
            _context = context;
        }

        public Grade GetById(int id)
        {
            var grades = _context.Read<Grade>("grades.csv");
            return grades.FirstOrDefault(g => g.Id == id);
        }

        public List<Grade> GetAll()
        {
            return _context.Read<Grade>("grades.csv");
        }

        public List<Grade> GetByStudentId(int studentId)
        {
            var grades = _context.Read<Grade>("grades.csv");
            return grades.Where(g => g.StudentId == studentId).ToList();
        }

        public List<Grade> GetByCourseId(int courseId)
        {
            var grades = _context.Read<Grade>("grades.csv");
            return grades.Where(g => g.CourseId == courseId).ToList();
        }

        public void Add(Grade grade)
        {
            var grades = _context.Read<Grade>("grades.csv");
            grade.Id = grades.Any() ? grades.Max(g => g.Id) + 1 : 1;
            grades.Add(grade);
            _context.Write("grades.csv", grades);
        }

        public void Update(Grade grade)
        {
            var grades = _context.Read<Grade>("grades.csv");
            var existing = grades.FirstOrDefault(g => g.Id == grade.Id);
            if (existing != null)
            {
                grades.Remove(existing);
                grades.Add(grade);
                _context.Write("grades.csv", grades);
            }
        }

        public void Delete(int gradeId)
        {
            var grades = _context.Read<Grade>("grades.csv");
            var grade = grades.FirstOrDefault(g => g.Id == gradeId);
            if (grade != null)
            {
                grades.Remove(grade);
                _context.Write("grades.csv", grades);
            }
        }
    }
}