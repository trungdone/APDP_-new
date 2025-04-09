using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        void Add(User user);
        List<User> GetAll();
        void Update(User user);
        User GetById(int id);

    }
}
