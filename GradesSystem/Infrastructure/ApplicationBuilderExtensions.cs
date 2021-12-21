namespace GradesSystem.Infrastructure
{
    using GradesSystem.Data;
    using GradesSystem.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;

            MigrateDatabase(services);

            SeedSubjects(services);
            //SeedAdministrator(services);

            return app;
        }
        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void SeedSubjects(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Subjects.Any())
            {
                return;
            }

            data.Subjects.AddRange(new[]
            {
                new Subject { SubjectName = "Автоматизация на инжинерния труд" },
                new Subject { SubjectName = "Бази данни" },
                new Subject { SubjectName = "Икономика" },
                new Subject { SubjectName = "Сигнали и ситеми" },
                new Subject { SubjectName = "Програмиране и използване на компютри" },
                new Subject { SubjectName = "Информационни системи" },
                new Subject { SubjectName = "Операционни системи" }
            });

            data.Students.AddRange(new[]
            {
                new Student{Year=1},
                new Student{Year=2},
                new Student{Year=3},
                new Student{Year=4}
            });

            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            //var userManager = services.GetRequiredService<UserManager<User>>();
            //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            //Task
            //    .Run(async () =>
            //    {
            //        if (await roleManager.RoleExistsAsync(AdministratorRoleName))
            //        {
            //            return;
            //        }

            //        var role = new IdentityRole { Name = AdministratorRoleName };

            //        await roleManager.CreateAsync(role);

            //        const string adminEmail = "admin@crs.com";
            //        const string adminPassword = "admin12";

            //        var user = new User
            //        {
            //            Email = adminEmail,
            //            UserName = adminEmail,
            //            FullName = "Admin"
            //        };

            //        await userManager.CreateAsync(user, adminPassword);

            //        await userManager.AddToRoleAsync(user, role.Name);
            //    })
            //    .GetAwaiter()
            //    .GetResult();
        }
    }
}