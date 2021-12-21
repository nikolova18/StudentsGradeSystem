namespace GradesSystem.Models
{
    using GradesSystem.Models.Students;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public int TotalStudents { get; init; }

        public int TotalUsers { get; init; }

        public List<StudentIndexViewModel> Students { get; init; }
    }
}
