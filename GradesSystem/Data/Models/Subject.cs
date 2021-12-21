namespace GradesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;


    public class Subject
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(SubjectFacultyNameLength)]
        public string SubjectName { get; set; }

        public IEnumerable<Student> Students { get; init; } = new List<Student>();

    }
}
