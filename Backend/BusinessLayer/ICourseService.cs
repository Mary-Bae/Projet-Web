using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
        public Course? Get(string name);
        void addCourse(Course course);
        void deleteCourse(Course course);
        void UpdateCourse(Course course);
    }
}
