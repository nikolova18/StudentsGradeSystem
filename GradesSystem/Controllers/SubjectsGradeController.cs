namespace GradesSystem.Controllers
{
    using GradesSystem.Data;
    using GradesSystem.Data.Models;
    using GradesSystem.Models.SubjectsGrades;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class SubjectsGradeController : Controller
    {
        private readonly ApplicationDbContext data;
        public SubjectsGradeController(ApplicationDbContext data)
            => this.data = data;
        public IActionResult Add() => View(new AddSubjectGradeFormModel
        {
            SubjectsName = this.GetSubjectsNames()
        });

        [HttpPost]
        public IActionResult Add(AddSubjectGradeFormModel subjectgrade)
        {
            var student = this.data.Students.First(st => st.FacultyNumber == subjectgrade.FacultyNumber).Id;

            var subject = this.data.Subjects.First(st => st.SubjectName == subjectgrade.SubjectName).Id;

            var studentName = this.data.Students.First(st => st.FacultyNumber == subjectgrade.FacultyNumber).FirstName;
            var studentLastName = this.data.Students.First(st => st.FacultyNumber == subjectgrade.FacultyNumber).LastName;

            var gradeData = new SubjectGrades
            {
                StudentId = student,
                SubjectId = subject,
                StudentName = studentName+" "+studentLastName,
                SubjectName=subjectgrade.SubjectName,
                Grade =subjectgrade.Grade
            };


            this.data.SubjectGrades.Add(gradeData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }
        public IActionResult All([FromQuery] AllSubjectGradesQueryModel query)
        {
            var subjectsGradesQuery = this.data.SubjectGrades.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SubjectName))
            {
                subjectsGradesQuery = subjectsGradesQuery.Where(p => p.SubjectName == query.SubjectName);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                subjectsGradesQuery = subjectsGradesQuery.Where(p =>(
                    p.StudentName).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            subjectsGradesQuery = query.Sorting switch
            {
                SubjectGradeSorting.Subjects => subjectsGradesQuery.OrderBy(p => p.SubjectName),
                SubjectGradeSorting.Student => subjectsGradesQuery.OrderBy(p => p.StudentName),
                SubjectGradeSorting.Grade=> subjectsGradesQuery.OrderBy(p => p.Grade),
                SubjectGradeSorting.GradeD or _ => subjectsGradesQuery.OrderByDescending(p => p.Grade)
            };

            var totalgrades = subjectsGradesQuery.Count();

            var students = subjectsGradesQuery
                .Select(p => new SubjectGradeListingViewModel
                    {
                    StudentId=p.StudentId,
                    SubjectId=p.SubjectId,
                    StudentName=p.StudentName,
                    SubjectName=p.SubjectName,
                    Grade=p.Grade})
                .ToList();

            var grades = subjectsGradesQuery.Select(p => p.Grade)
                .ToList();
            
            var subjectNames = subjectsGradesQuery.Select(p => p.SubjectName)
                .Distinct().ToList();
           
            query.SubjectNames = subjectNames;
            query.Grades = grades;
            query.Students = students;



            return View(query);
        }


        private IEnumerable<SubjectNameViewModel> GetSubjectsNames()
           => this.data
           .Subjects
           .Select(c => new SubjectNameViewModel
           {
               Id = c.Id,
               Name = c.SubjectName
           })
           .ToList();
    }
}
