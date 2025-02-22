using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inmind_DDD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TimeSlots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TimeSlots_TimeSlotId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TimeSlotId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TimeSlots",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_TeacherId",
                table: "TimeSlots",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Teachers_TeacherId",
                table: "TimeSlots",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Teachers_TeacherId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_TeacherId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TimeSlots");

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "Teachers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TimeSlotId",
                table: "Teachers",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TimeSlots_TimeSlotId",
                table: "Teachers",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
