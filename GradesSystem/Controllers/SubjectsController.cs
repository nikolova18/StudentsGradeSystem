namespace GradesSystem.Controllers
{
    using GradesSystem.Data;
    using GradesSystem.Data.Models;
    using GradesSystem.Models.Subjects;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class SubjectsController : Controller
    {
        private readonly ApplicationDbContext data;
        public SubjectsController(ApplicationDbContext data)
            => this.data = data;

        public IActionResult All([FromQuery] AllSubjectsQueryModel query)
        {
            var subjectsQuery = this.data.Subjects.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SubjectName))
            {
                subjectsQuery = subjectsQuery.Where(p => p.SubjectName == query.SubjectName);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                subjectsQuery = subjectsQuery.Where(p =>
                      (p.SubjectName).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            var totalSubjects = subjectsQuery.Count();

            var subjects = subjectsQuery
                .Select(p => new SubjectsListingViewModel
                {
                    Id = p.Id,
                    SubjectName = p.SubjectName
                })
                .ToList();

            var subjectNames = this.data
                .Subjects
                .Select(p => p.SubjectName)
                .Distinct()
                .ToList();

            query.SubjectNames = subjectNames;
            query.TotalSubjects = totalSubjects;

            return View(query);
        }


        public IActionResult Add() => View(new AddSubjectFormModel
        {
        });

        [HttpPost]
        public IActionResult Add(AddSubjectFormModel subject)
        {
            var subjectdata = new Subject
            {
                SubjectName = subject.SubjectName
            };
            this.data.Subjects.Add(subjectdata);
            this.data.SaveChanges();
            return View();
        }


    }
}
