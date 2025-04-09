using SIMS_Project.SIMS.Core.Interfaces.Repositories;
using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Application.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public Class GetClassById(int id)
        {
            return _classRepository.GetById(id);
        }

        public List<Class> GetAllClasses()
        {
            return _classRepository.GetAll();
        }

        public void AddClass(Class classEntity)
        {
            _classRepository.Add(classEntity);
        }

        public void UpdateClass(Class classEntity)
        {
            _classRepository.Update(classEntity);
        }

        public void DeleteClass(int classId)
        {
            _classRepository.Delete(classId);
        }

        public List<Class> GetClassesByCourseId(int courseId)
        {
            return _classRepository.GetAll().Where(c => c.CourseId == courseId).ToList();
        }

        public List<Class> GetClassesByTeacherId(int teacherId)
        {
            return _classRepository.GetAll().Where(c => c.TeacherId == teacherId).ToList();
        }

        public void RemoveStudentFromClass(int classId, int studentId)
        {
            var classEntity = _classRepository.GetById(classId);
            if (classEntity != null && classEntity.StudentIds.Contains(studentId))
            {
                classEntity.StudentIds.Remove(studentId);
                _classRepository.Update(classEntity);
            }
        }
    }
}