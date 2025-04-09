using SIMS_Project.SIMS.Core.Interfaces.Repositories;
using SIMS_Project.SIMS.Core.Models;
using SIMS_Project.SIMS.Infrastructure.Data.Contexts;

namespace SIMS_Project.SIMS.Infrastructure.Data.Repositories
{
    public class CsvClassRepository : IClassRepository
    {
        private readonly CsvDataContext _context;

        public CsvClassRepository(CsvDataContext context)
        {
            _context = context;
        }

        public Class GetById(int id)
        {
            var classes = _context.Read<Class>("classes.csv");
            return classes.FirstOrDefault(c => c.Id == id);
        }

        public List<Class> GetAll()
        {
            return _context.Read<Class>("classes.csv");
        }

        public void Add(Class classEntity)
        {
            var classes = _context.Read<Class>("classes.csv");
            classEntity.Id = classes.Any() ? classes.Max(c => c.Id) + 1 : 1;
            classes.Add(classEntity);
            _context.Write("classes.csv", classes);
        }

        public void Update(Class classEntity)
        {
            var classes = _context.Read<Class>("classes.csv");
            var existing = classes.FirstOrDefault(c => c.Id == classEntity.Id);
            if (existing != null)
            {
                classes.Remove(existing);
                classes.Add(classEntity);
                _context.Write("classes.csv", classes);
            }
        }

        public void Delete(int classId)
        {
            var classes = _context.Read<Class>("classes.csv");
            var classEntity = classes.FirstOrDefault(c => c.Id == classId);
            if (classEntity != null)
            {
                classes.Remove(classEntity);
                _context.Write("classes.csv", classes);
            }
        }
    }
}