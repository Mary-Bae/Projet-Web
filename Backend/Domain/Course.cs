using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Schedule { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public string Description { get; set; }


        //public Course(string name, string level, string schedule, string teacher, string description)
        //{
        //    Name = name;
        //    Level = level;
        //    Schedule = schedule;
        //    Teacher = teacher;
        //    Description = description;
        //}
    }
}
