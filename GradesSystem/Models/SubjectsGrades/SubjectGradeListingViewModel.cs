namespace GradesSystem.Models.SubjectsGrades
{
    public class SubjectGradeListingViewModel
    {
        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public string StudentName { get; set; }
        public string SubjectName { get; set; }

        public int Grade { get; set; }
    }
}
