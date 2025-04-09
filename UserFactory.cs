using SIMS_Project.SIMS.Core.Common.ValueObjects;
using SIMS_Project.SIMS.Core.Enums;
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Infrastructure.Factories
{
    // Factory Pattern: Tạo User theo UserType
    // OCP: Dễ mở rộng khi thêm loại User mới
    public class UserFactory
    {
        public User CreateUser(UserType type, string name, string email, string password, int? classId = null, int? courseId = null)
        {
            User user = type switch
            {
                UserType.Student => new Student(),
                UserType.Teacher => new Teacher(),
                UserType.Admin => new Admin(),
                _ => throw new ArgumentException("Invalid user type")
            };

            user.Name = name;
            user.Email = new Email(email);
            user.PasswordHash = password;
            user.Type = type;
            user.ClassId = classId;
            user.CourseId = courseId;

            // Gán role mặc định
            user.Role = type switch
            {
                UserType.Student => Role.ReadOnly,
                UserType.Teacher => Role.Editor,
                UserType.Admin => Role.Manager,
                _ => Role.ReadOnly
            };

            return user;
        }
    }
}