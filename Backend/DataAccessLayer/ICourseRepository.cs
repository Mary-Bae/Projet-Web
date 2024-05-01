using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course Get(int id);
        void addCourse(Course course);
        void deleteCourse(Course course);
        void UpdateCourse(Course course);

    }
}
