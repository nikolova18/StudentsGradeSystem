namespace GradesSystem.Controllers
{
    using GradesSystem.Data;
    using GradesSystem.Models;
    using GradesSystem.Models.Students;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext data;

        public HomeController(ApplicationDbContext data)
            => this.data = data;

        public IActionResult Index()
        {
            var totalStudents = this.data.Students.Count();

            var students = this.data
                .Students
                .OrderByDescending(p => p.Id)
                .Select(s => new StudentIndexViewModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    FacultyName = s.FacultyName,
                    FacultyNumber = s.FacultyNumber,
                    Year = s.Year
                })
                .Take(36)
                .ToList();

            return View(new IndexViewModel
            {
                TotalStudents = totalStudents,
                Students = students
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
    }
}
