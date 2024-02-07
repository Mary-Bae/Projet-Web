using BusinessLayer;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            try
            {
                return Ok(_courseService.GetAll());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("ByName")]
        [Authorize(Roles = "Admin")]
        public Course? Get(string name)
        {
            return _courseService.Get(name);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void PostCourses(Course course)
        {
            _courseService.addCourse(course);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public void DeleteCourses(Course course)
        {
            _courseService.deleteCourse(course);
        }
    }
}