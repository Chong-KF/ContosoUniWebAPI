using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ContosoUniWebAPI.Models
{
    public static class Grade
    {
        public const char
            A = 'A',
            B = 'B',
            C = 'C',
            D = 'D',
            E = 'E',
            F = 'F';
    }

    public partial class Enrollment
    {
        public int Id { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public char? Grade { get; set; }

        //public virtual Course CourseFkNavigation { get; set; }
        //public virtual Student StudentFkNavigation { get; set; }

        public Course Course { get; set; }

        //public Student Student { get; set; }
    }
}
