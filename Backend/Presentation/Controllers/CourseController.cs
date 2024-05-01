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

        [HttpGet("ById")]
        [Authorize(Roles = "Admin")]
        public Course? Get(int id)
        {
            return _courseService.Get(id);
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

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Course> PutCourse(int id, Course updatedCourse)
        {
            if (id != updatedCourse.Id)
            {
                return BadRequest();
            }

            try
            {
                _courseService.UpdateCourse(updatedCourse);
                return Ok(updatedCourse);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the course.");
            }
        }

    }
}