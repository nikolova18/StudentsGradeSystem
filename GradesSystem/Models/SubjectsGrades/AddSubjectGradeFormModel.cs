namespace GradesSystem.Models.SubjectsGrades
{
    using GradesSystem.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class AddSubjectGradeFormModel
    {
        public int StudentId { get; set; }
        [Display(Name = "Факултетен номер/ Имена на студент")]
        public string StudentName { get; set; }

        public int SubjectId { get; set; }
        [Display(Name = "Предмет")]
        public string SubjectName { get; set; }
        [Display(Name ="Факултетен номер")]
        [MaxLength(FacultyNumberLength)]
        public string FacultyNumber { get; set; }

        [Display(Name ="Оценка")]
        public int Grade { get; set; }


        public IEnumerable<SubjectNameViewModel> SubjectsName { get; init; } = new List<SubjectNameViewModel>();

    }
}
