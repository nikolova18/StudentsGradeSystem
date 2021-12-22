using Microsoft.EntityFrameworkCore.Migrations;

namespace GradesSystem.Data.Migrations
{
    public partial class SubjectGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGrades_Students_StudentId",
                table: "SubjectGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGrades_Subjects_SubjectId",
                table: "SubjectGrades");

            migrationBuilder.DropIndex(
                name: "IX_SubjectGrades_SubjectId",
                table: "SubjectGrades");

            migrationBuilder.AddColumn<int>(
                name: "SubjectGradesStudentId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectGradesSubjectId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "SubjectGrades",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "SubjectGrades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "SubjectGrades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacultyName",
                table: "Students",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectGradesStudentId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectGradesSubjectId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectGradesStudentId_SubjectGradesSubjectId",
                table: "Subjects",
                columns: new[] { "SubjectGradesStudentId", "SubjectGradesSubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SubjectGradesStudentId_SubjectGradesSubjectId",
                table: "Students",
                columns: new[] { "SubjectGradesStudentId", "SubjectGradesSubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SubjectGrades_SubjectGradesStudentId_SubjectGradesSubjectId",
                table: "Students",
                columns: new[] { "SubjectGradesStudentId", "SubjectGradesSubjectId" },
                principalTable: "SubjectGrades",
                principalColumns: new[] { "StudentId", "SubjectId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_SubjectGrades_SubjectGradesStudentId_SubjectGradesSubjectId",
                table: "Subjects",
                columns: new[] { "SubjectGradesStudentId", "SubjectGradesSubjectId" },
                principalTable: "SubjectGrades",
                principalColumns: new[] { "StudentId", "SubjectId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_SubjectGrades_SubjectGradesStudentId_SubjectGradesSubjectId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_SubjectGrades_SubjectGradesStudentId_SubjectGradesSubjectId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SubjectGradesStudentId_SubjectGradesSubjectId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Students_SubjectGradesStudentId_SubjectGradesSubjectId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectGradesStudentId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectGradesSubjectId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "SubjectGrades");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "SubjectGrades");

            migrationBuilder.DropColumn(
                name: "SubjectGradesStudentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectGradesSubjectId",
                table: "Students");

            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "SubjectGrades",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyName",
                table: "Students",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGrades_SubjectId",
                table: "SubjectGrades",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGrades_Students_StudentId",
                table: "SubjectGrades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGrades_Subjects_SubjectId",
                table: "SubjectGrades",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
