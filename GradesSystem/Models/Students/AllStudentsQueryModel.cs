namespace GradesSystem.Models.Students
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllStudentsQueryModel
    {
        public const int StudentsPerPage = 9;

        public string FacultyNumber { get; init; }
        public IEnumerable<string> FacultyNumbers { get; set; }


        public string FacultyName { get; init; }
        public IEnumerable<string> FacultyNames { get; set; }

        public int Year { get; set; }


        [Display(Name = "Search by text:")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalStudents { get; set; }

        public StudentSorting Sorting { get; init; }

        public IEnumerable<StudentListingViewModel> Students { get; set; }
    }
}
