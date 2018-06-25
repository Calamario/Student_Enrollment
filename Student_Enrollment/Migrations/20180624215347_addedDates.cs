using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Enrollment.Migrations
{
    public partial class addedDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_ClassNameID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "dayTrack",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "ClassNameID",
                table: "Student",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_ClassNameID",
                table: "Student",
                newName: "IX_Student_CourseID");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Course",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDate",
                table: "Course",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_CourseID",
                table: "Student",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_CourseID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "StartingDate",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Student",
                newName: "ClassNameID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_CourseID",
                table: "Student",
                newName: "IX_Student_ClassNameID");

            migrationBuilder.AddColumn<bool>(
                name: "dayTrack",
                table: "Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_ClassNameID",
                table: "Student",
                column: "ClassNameID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
