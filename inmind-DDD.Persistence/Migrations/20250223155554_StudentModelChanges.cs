using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inmind_DDD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StudentModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalNumberOfGrades",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalNumberOfGrades",
                table: "Students");
        }
    }
}
