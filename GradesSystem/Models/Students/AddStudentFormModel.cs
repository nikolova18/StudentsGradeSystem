using GradesSystem.Data;

namespace GradesSystem.Models.Students
{
    using GradesSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class AddStudentFormModel
    {
        [Required]
        [MaxLength(FacultyNumberLength)]
        [Display(Name = "Факултетен номер")]
        public string FacultyNumber { get; init; }

        [Required]
        [MaxLength(FirstNameLength)]
        [Display(Name = "Име")]
        public string FirstName { get; init; }

        [Required]
        [MaxLength(LastNameLength)]
        [Display(Name = "Фамилия")]

        public string LastName { get; init; }

        [Required]
        [MaxLength(SubjectFacultyNameLength)]
        [Display(Name = "Специалност")]
        public string FacultyName { get; init; }

        [Required]
        [Range(1, 4)]
        [Display(Name = "Година на обучение")]
        public int Year { get; init; }

        public IEnumerable<Subject> Subjects { get; init; } = new List<Subject>();
        public IEnumerable<StudentYearViewModel> Years { get; set; } = new List<StudentYearViewModel>();
    }
}
