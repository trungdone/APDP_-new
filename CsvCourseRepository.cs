using SIMS_Project.SIMS.Core.Interfaces.Repositories;
using SIMS_Project.SIMS.Core.Models;
using SIMS_Project.SIMS.Infrastructure.Data.Contexts;

namespace SIMS_Project.SIMS.Infrastructure.Data.Repositories
{
    public class CsvCourseRepository : ICourseRepository
    {
        private readonly CsvDataContext _context;

        public CsvCourseRepository(CsvDataContext context)
        {
            _context = context;
        }

        public Course GetById(int id)
        {
            var courses = _context.Read<Course>("courses.csv");
            return courses.FirstOrDefault(c => c.Id == id);
        }

        public List<Course> GetAll()
        {
            return _context.Read<Course>("courses.csv");
        }

        public void Add(Course course)
        {
            var courses = _context.Read<Course>("courses.csv");
            course.Id = courses.Any() ? courses.Max(c => c.Id) + 1 : 1;
            courses.Add(course);
            _context.Write("courses.csv", courses);
        }

        public void Update(Course course)
        {
            var courses = _context.Read<Course>("courses.csv");
            var existing = courses.FirstOrDefault(c => c.Id == course.Id);
            if (existing != null)
            {
                courses.Remove(existing);
                courses.Add(course);
                _context.Write("courses.csv", courses);
            }
        }

        public void Delete(int courseId)
        {
            var courses = _context.Read<Course>("courses.csv");
            var course = courses.FirstOrDefault(c => c.Id == courseId);
            if (course != null)
            {
                courses.Remove(course);
                _context.Write("courses.csv", courses);
            }
        }
    }
}