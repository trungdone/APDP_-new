using SIMS_Project.SIMS.Core.Interfaces.Repositories;
using SIMS_Project.SIMS.Core.Models;
using SIMS_Project.SIMS.Infrastructure.Data.Contexts;
using System.Linq;

namespace SIMS_Project.SIMS.Infrastructure.Data.Repositories
{
    public class CsvUserRepository : IUserRepository
    {
        private readonly CsvDataContext _context;

        public CsvUserRepository(CsvDataContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            var users = _context.ReadUsers("users.csv");
            return users.FirstOrDefault(u => u.Id == id);
        }

        public User GetByEmail(string email)
        {
            var users = _context.ReadUsers("users.csv");
            return users.FirstOrDefault(u => u.Email.Value == email);
        }

        public List<User> GetAll()
        {
            return _context.ReadUsers("users.csv");
        }

        public void Add(User user)
        {
            var users = _context.ReadUsers("users.csv");
            user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
            users.Add(user);
            _context.Write("users.csv", users);
        }

        public void Update(User user)
        {
            var users = _context.ReadUsers("users.csv");
            var existing = users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                users.Remove(existing);
                users.Add(user);
                _context.Write("users.csv", users);
            }
        }

        public void Delete(int userId)
        {
            var users = _context.ReadUsers("users.csv");
            var user = users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                users.Remove(user);
                _context.Write("users.csv", users); // Đảm bảo ghi lại file sau khi xóa
            }
        }
    }
}