﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
