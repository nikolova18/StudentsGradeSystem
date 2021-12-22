namespace GradesSystem.Models.SubjectsGrades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class AllSubjectGradesQueryModel
    {
        public string SubjectName { get; init; }
        public IEnumerable<string> SubjectNames { get; set; }
        public string StudentFirstName { get; init; }
        public string StudentLastName { get; init; }
        public string FacultyNumber { get; init; }

        public int Grade { get; init; }
        public IEnumerable<int> Grades { get; set; }


        [Display(Name = "Търси по име или предмет:")]
        public string SearchTerm { get; init; }

        public int TotalGrades { get; set; }

        public IEnumerable<SubjectGradeListingViewModel> Students { get; set; }
        public SubjectGradeSorting Sorting { get; init; }
    }
}
