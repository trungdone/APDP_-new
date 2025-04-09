using SIMS_Project.SIMS.Core.Enums;
using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Core.Models;
using SIMS_Project.SIMS.Infrastructure.Factories;
using SIMS_Project.SIMS.Core.Interfaces.Repositories;
using SIMS_Project.SIMS.Core.Exceptions;
using SIMS_Project.SIMS.Infrastructure.Utilities;

namespace SIMS_Project.SIMS.Application.Services
{
    // SRP: Chỉ xử lý logic nghiệp vụ User
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserFactory _userFactory;
        private User _currentUser;

        public UserService(IUserRepository userRepository, UserFactory userFactory)
        {
            _userRepository = userRepository; // DIP
            _userFactory = userFactory;
        }

        public User Login(string email, string password, UserType type)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null)
                throw new UserNotFoundException("Invalid email, password, or user type.");
            if (user.PasswordHash != HashingUtility.HashPassword(password))
                throw new UserNotFoundException("Invalid email, password, or user type.");
            if (user.Type != type)
                throw new UserNotFoundException("Invalid email, password, or user type.");
            _currentUser = user;
            return user;
        }

        public void Register(User user, string verificationCode = null)
        {
            // Kiểm tra email đã tồn tại
            var existingUser = _userRepository.GetAll().FirstOrDefault(u => u.Email.Value == user.Email.Value);
            if (existingUser != null)
                throw new DuplicateRecordException("Email already exists.");

            // Xác thực cho Admin và Teacher
            if (user.Type == UserType.Admin || user.Type == UserType.Teacher)
            {
                if (string.IsNullOrEmpty(verificationCode) || verificationCode != "SECRET_CODE")
                    throw new AuthorizationException("Verification required for Admin/Teacher.");
            }

            // Mã hóa mật khẩu trước khi lưu
            user.PasswordHash = HashingUtility.HashPassword(user.PasswordHash);
            _userRepository.Add(user);
        }

        public User GetCurrentUser() => _currentUser;

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(int userId)
        {

        }

        public void RemoveUserFromCourse(int userId, int courseId)
        {
            var user = _userRepository.GetById(userId);
            if (user is Student student)
            {
                student.EnrolledCourseIds.Remove(courseId);
                _userRepository.Update(student);
            }
            else if (user is Teacher teacher)
            {
                teacher.TeachingCourseIds.Remove(courseId);
                _userRepository.Update(teacher);
            }
        }
    }
}