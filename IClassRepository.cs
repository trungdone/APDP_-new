using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Repositories
{
    public interface IClassRepository
    {
        Class GetById(int id);
        void Add(Class classEntity);
        List<Class> GetAll();
        void Update(Class classEntity);
        void Delete(int classId);
    }
}
