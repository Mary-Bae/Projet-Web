using Domain;

namespace DataAccessLayer
{
    public class CourseRepository : ICourseRepository
    {
        private static List<Course> _db = new List<Course>
        {
            new Course("Web","Beginner","Day", "Teacher 1", "Cours de Web"),
            new Course("Développement","Beginner","Day", "Teacher 2","Cours de développement"),
            new Course("Java","Beginner","Day", "Teacher 3", "Cours de Java"),
            new Course("C#","Beginner","Day", "Teacher 4","Cours de C#")
         };
        public IEnumerable<Course> GetAll()
        {
            return _db;
        }
        public IEnumerable<Course> Get(string name)
        {
            return _db;
        }
        public void addCourse(Course course)
        {
            _db.Add(course);
        }
        public void deleteCourse(Course course)
        {
            _db.Remove(course);
        }
        public void UpdateCourse(Course course)
        {
            var existingCourse = _db.FirstOrDefault(c => c.Name.ToLower() == course.Name.ToLower());
            if (existingCourse != null)
            {
                existingCourse.Level = course.Level;
                existingCourse.Schedule = course.Schedule;
                existingCourse.Teacher = course.Teacher;
                existingCourse.Description = course.Description;
            }
            else
            {
                throw new Exception("Course not found");
            }
        }

    }
}