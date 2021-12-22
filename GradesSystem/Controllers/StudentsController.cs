namespace GradesSystem.Controllers
{
    using GradesSystem.Data;
    using GradesSystem.Data.Models;
    using GradesSystem.Models.Students;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsController:Controller
    {
        private readonly ApplicationDbContext data;

        public StudentsController(ApplicationDbContext data)
            => this.data = data;

       
        public IActionResult All([FromQuery] AllStudentsQueryModel query)
        {
            var studentsQuery = this.data.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.FacultyName))
            {
                studentsQuery = studentsQuery.Where(p => p.FacultyName == query.FacultyName);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                studentsQuery = studentsQuery.Where(p =>
                      (p.FacultyName + " " + p.FirstName + " "+ p.LastName).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            studentsQuery = query.Sorting switch
            {
                StudentSorting.FacultyName => studentsQuery.OrderBy(p => p.FacultyName),
                StudentSorting.Year => studentsQuery.OrderBy(p => p.Year),
                StudentSorting.YearD => studentsQuery.OrderByDescending(p => p.Year),
                StudentSorting.FacultyNumber => studentsQuery.OrderBy(p => p.FacultyNumber),
                StudentSorting.DateCreated or _ => studentsQuery.OrderByDescending(p => p.Id)
            };

            var totalstudents = studentsQuery.Count();

            var students = studentsQuery
                .Skip((query.CurrentPage - 1) * AllStudentsQueryModel.StudentsPerPage)
                .Take(AllStudentsQueryModel.StudentsPerPage)
                .Select(p => new StudentListingViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    FacultyNumber = p.FacultyNumber,
                    FacultyName = p.FacultyName,
                    Year = p.Year                
                })
                .ToList();

            var studentsFaculty = this.data
                .Students
                .Select(p => p.FacultyName)
                .Distinct()
                .ToList();

            query.FacultyNames = studentsFaculty;
            query.Students = students;
            query.TotalStudents = totalstudents;

            return View(query);
        }
        public IActionResult Add() => View(new AddStudentFormModel
        {
            Years = this.GetYear()
        });

        [HttpPost]
        public IActionResult Add(AddStudentFormModel student)
        {
            var studentData = new Student
            {
                FacultyNumber = student.FacultyNumber,
                FirstName = student.FirstName,
                LastName = student.LastName,
                FacultyName = student.FacultyName,
                Year = student.Year
            };

            this.data.Students.Add(studentData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private IEnumerable<StudentYearViewModel> GetYear()
           => this.data
           .Students
           .Select(c => new StudentYearViewModel
           {
               Id = c.Id,
               Year = c.Year
           })
           .ToList();
    }
}
