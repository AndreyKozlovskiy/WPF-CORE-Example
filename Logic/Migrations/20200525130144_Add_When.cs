using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class Add_When : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EducationName",
                table: "WorkExperiences");

            migrationBuilder.AddColumn<string>(
                name: "OrghanizationName",
                table: "WorkExperiences",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Resumes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrghanizationName",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Resumes");

            migrationBuilder.AddColumn<string>(
                name: "EducationName",
                table: "WorkExperiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
