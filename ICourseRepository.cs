using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Course GetById(int id);
        void Add(Course course);
        List<Course> GetAll();
        void Update(Course course);
        void Delete(int courseId);
    }
}
