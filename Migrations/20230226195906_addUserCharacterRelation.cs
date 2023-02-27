using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendkeystore.Migrations
{
    /// <inheritdoc />
    public partial class addUserCharacterRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Receipts",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_UserId",
                table: "Receipts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Users_UserId",
                table: "Receipts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Users_UserId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_UserId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Receipts");
        }
    }
}
