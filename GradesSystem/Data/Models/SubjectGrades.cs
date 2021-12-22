namespace GradesSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SubjectGrades
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }


        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        [Range(2,6)]
        public int Grade { get; set; }
        //public IEnumerable<Subject> Subjects { get; set; } = new List<Subject>();
        //public IEnumerable<Student> Students { get; set; } = new List<Student>();

    }
}
