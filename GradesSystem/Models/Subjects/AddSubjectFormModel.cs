using GradesSystem.Data;

namespace GradesSystem.Models.Subjects
{
    using GradesSystem.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class AddSubjectFormModel
    {
        [Required]
        [MaxLength(SubjectFacultyNameLength)]
        [Display(Name ="Име на предмета")]
        public string SubjectName { get; set; }

        public IEnumerable<Subject> Subjects { get; init; } = new List<Subject>();

        public IEnumerable<Student> Students { get; init; } = new List<Student>();
    }
}
