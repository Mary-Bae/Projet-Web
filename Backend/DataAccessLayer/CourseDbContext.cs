using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CourseDbContext : DbContext
    {
        public virtual DbSet<Course> Courses {get; set;} //Creation de table course
        public virtual DbSet<Teacher> Teachers {get; set;} //Creation de table Teacher
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {

        }
    }
}
