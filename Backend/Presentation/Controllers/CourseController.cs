using BusinessLayer;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
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
        public Course? Get(string name)
        {
            return _courseService.Get(name);
        }

        [HttpPost]
        public void PostCourses(Course course)
        {
            _courseService.addCourse(course);
        }

        [HttpDelete]
        public void DeleteCourses(Course course)
        {
            _courseService.deleteCourse(course);
        }
    }

}