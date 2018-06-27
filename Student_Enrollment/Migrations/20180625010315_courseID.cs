using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Enrollment.Migrations
{
    public partial class courseID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_CourseID",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Student",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_CourseID",
                table: "Student",
                newName: "IX_Student_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Student",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_CourseId",
                table: "Student",
                newName: "IX_Student_CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_CourseID",
                table: "Student",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
