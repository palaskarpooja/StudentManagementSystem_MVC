using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagementSystem_MVC.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
