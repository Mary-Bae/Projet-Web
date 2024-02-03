using DataAccessLayer;
using Domain;

namespace BusinessLayer
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public IEnumerable<Course> GetAll()
        {
            var course = _courseRepository.GetAll();

            course.ToList().ForEach(course => course.Name = course.Name.ToUpper());
            return course;
        }
        public Course? Get(string name)
        {
            return _courseRepository.GetAll().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
        public void addCourse(Course course)
        {
            _courseRepository.addCourse(course);
        }

        public void deleteCourse(Course course)
        {
            _courseRepository.deleteCourse(course);
        }
    }


}