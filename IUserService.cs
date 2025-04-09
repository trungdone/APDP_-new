using SIMS_Project.SIMS.Core.Enums;
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Core.Interfaces.Services
{
    // ISP: Chỉ chứa phương thức liên quan đến User
    public interface IUserService
    {
        User Login(string email, string password, UserType type);
        void Register(User user, string verificationCode = null);
        User GetCurrentUser();
        List<User> GetAllUsers(); // Admin lấy danh sách user
        void UpdateUser(User user); // Cập nhật thông tin user
        void RemoveUserFromCourse(int userId, int courseId); // Loại user khỏi khóa học
        void DeleteUser(int userId);
    }
}
