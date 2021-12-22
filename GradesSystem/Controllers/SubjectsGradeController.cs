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
            Students = this.GetStudentsNames(),
            Subjects = this.GetSubjectsNames()
        });

        [HttpPost]
        public IActionResult Add(AddSubjectGradeFormModel subjectgrade)
        {
            var gradeData = new SubjectGrades
            {
                StudentId=subjectgrade.StudentId,
                StudentName=subjectgrade.StudentName,
                SubjectId = subjectgrade.SubjectId,
                Subject=subjectgrade.SubjectName,
                Grade =subjectgrade.Grade
            };

            this.data.SubjectGrades.Add(gradeData);
            this.data.SaveChanges();

            return View();
        }
        public IActionResult All([FromQuery] AllSubjectGradesQueryModel query)
        {
            return View();
        }

        private IEnumerable<StudentNameViewModel> GetStudentsNames()
            => this.data
            .Students
            .Select(c => new StudentNameViewModel
            {
                Id = c.Id,
                Name = c.FirstName+" "+c.LastName ,
                FacultyNumber = c.FacultyNumber,
            })
            .ToList();

        private IEnumerable<SubjectNameVIewModel> GetSubjectsNames()
           => this.data
           .Subjects
           .Select(c => new SubjectNameVIewModel
           {
               Id = c.Id,
               SubjectName = c.SubjectName
           })
           .ToList();


    }
}
