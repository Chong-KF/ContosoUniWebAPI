using System;
using System.Collections.Generic;

#nullable disable

namespace ContosoUniWebAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public short Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
