using System;
using System.Collections.Generic;
using System.Text;

namespace _3_praktine
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LecturerSubjectId { get; set; }
        public float StudentGrade { get; set; }
    }
}
