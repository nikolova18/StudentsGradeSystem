namespace GradesSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SubjectGrades
    {
        [Key]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Key]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Range(2,6)]
        public double Grade { get; set; }
    }
}
