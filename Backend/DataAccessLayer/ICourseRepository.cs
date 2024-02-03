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
        public IEnumerable<Course> Get(string name);
    }
}
