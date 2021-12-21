namespace GradesSystem.Models.Subjects
{
    using GradesSystem.Models.Students;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllSubjectsQueryModel
    {
        public string SubjectName { get; init; }
        public IEnumerable<string> SubjectNames { get; set; }

        [Display(Name = "Search by text:")]
        public string SearchTerm { get; init; }

        public int TotalSubjects { get; set; }

        public IEnumerable<StudentListingViewModel> Students { get; set; }
        public SubjectSorting Sorting { get; init; }


    }
}
