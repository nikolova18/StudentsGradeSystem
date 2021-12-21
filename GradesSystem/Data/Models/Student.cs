namespace GradesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Student
    {
        public int Id{get;init;}

        [Required]
        [MaxLength(FacultyNumberLength)]
        public string FacultyNumber { get; set; }

        [Required]
        [MaxLength(FirstNameLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(LastNameLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(SubjectFacultyNameLength)]
        public string FacultyName { get; set; }
        
        [Required]
        [Range(1,4)]
        public int Year { get; set; }

        public IEnumerable<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
