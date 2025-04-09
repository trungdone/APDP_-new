using Microsoft.AspNetCore.Mvc;
using SIMS_Project.SIMS.Application.Services;
using SIMS_Project.SIMS.Core.Interfaces.Services;
using SIMS_Project.SIMS.Core.Models;

namespace SIMS_Project.SIMS.Web.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // User Management
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _adminService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost("users")]
        public IActionResult AddUser([FromBody] User user)
        {
            _adminService.AddUser(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        [HttpPut("users/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
                return BadRequest();
            _adminService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _adminService.DeleteUser(id);
            return NoContent();
        }

        // Course Management
        [HttpGet("courses")]
        public IActionResult GetCourses()
        {
            var courses = _adminService.GetAllCourses();
            return Ok(courses);
        }

        [HttpPost("courses")]
        public IActionResult AddCourse([FromBody] Course course)
        {
            _adminService.AddCourse(course);
            return CreatedAtAction(nameof(GetCourses), new { id = course.Id }, course);
        }

        [HttpPut("courses/{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course course)
        {
            if (id != course.Id)
                return BadRequest();
            _adminService.UpdateCourse(course);
            return NoContent();
        }

        [HttpDelete("courses/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            _adminService.DeleteCourse(id);
            return NoContent();
        }

        // Class Management
        [HttpGet("classes")]
        public IActionResult GetClasses()
        {
            var classes = _adminService.GetAllClasses();
            return Ok(classes);
        }

        [HttpPost("classes")]
        public IActionResult AddClass([FromBody] Class classEntity)
        {
            _adminService.AddClass(classEntity);
            return CreatedAtAction(nameof(GetClasses), new { id = classEntity.Id }, classEntity);
        }

        [HttpPut("classes/{id}")]
        public IActionResult UpdateClass(int id, [FromBody] Class classEntity)
        {
            if (id != classEntity.Id)
                return BadRequest();
            _adminService.UpdateClass(classEntity);
            return NoContent();
        }

        [HttpDelete("classes/{id}")]
        public IActionResult DeleteClass(int id)
        {
            _adminService.DeleteClass(id);
            return NoContent();
        }

        // Attendance Management
        [HttpPost("attendance")]
        public IActionResult MarkAttendance([FromBody] AttendanceRecord attendance)
        {
            _adminService.MarkAttendance(attendance);
            return CreatedAtAction(nameof(GetAttendanceByClassId), new { classId = attendance.ClassId }, attendance);
        }

        [HttpPut("attendance/{id}")]
        public IActionResult UpdateAttendance(int id, [FromBody] AttendanceRecord attendance)
        {
            if (id != attendance.Id)
                return BadRequest();
            _adminService.UpdateAttendance(attendance);
            return NoContent();
        }

        [HttpDelete("attendance/{id}")]
        public IActionResult DeleteAttendance(int id)
        {
            _adminService.DeleteAttendance(id);
            return NoContent();
        }

        [HttpGet("attendance/course/{courseId}")]
        public IActionResult GetAttendanceByCourse(int courseId)
        {
            var attendance = _adminService.GetAttendanceByCourse(courseId);
            return Ok(attendance);
        }

        [HttpGet("attendance/class/{classId}")]
        public IActionResult GetAttendanceByClassId(int classId)
        {
            var attendance = _adminService.GetAttendanceByClassId(classId);
            return Ok(attendance);
        }
    }
}