namespace GradesSystem.Models.SubjectsGrades
{
    using GradesSystem.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddSubjectGradeFormModel
    {
        public int StudentId { get; set; }
        [Display(Name = "Факултетен номер/ Имена на студент")]

        public string StudentName { get; set; }

        public int SubjectId { get; set; }
        [Display(Name = "Предмет")]
        public string SubjectName { get; set; }


        [Display(Name ="Оценка")]
        public int Grade { get; set; }

        public IEnumerable<StudentNameViewModel> Students { get; init; } = new List<StudentNameViewModel>();

        public IEnumerable<SubjectNameVIewModel> Subjects { get; init; } = new List<SubjectNameVIewModel>();

    }
}
