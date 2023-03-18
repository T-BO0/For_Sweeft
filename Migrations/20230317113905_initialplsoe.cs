using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sweeft.Migrations
{
    public partial class initialplsoe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TeacherPupil",
                columns: new[] { "PupilId", "TeacherId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TeacherPupil",
                keyColumns: new[] { "PupilId", "TeacherId" },
                keyValues: new object[] { 1, 1 });
        }
    }
}
