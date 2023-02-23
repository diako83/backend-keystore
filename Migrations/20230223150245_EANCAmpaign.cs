using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backendkeystore.Migrations
{
    /// <inheritdoc />
    public partial class EANCAmpaign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EANCampaign",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CampaignEAN = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EANCampaign", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EANCampaign",
                columns: new[] { "Id", "CampaignEAN" },
                values: new object[,]
                {
                    { "1", 5000112637922L },
                    { "2", 5000112637939L },
                    { "3", 7310865004703L },
                    { "4", 7340005404261L },
                    { "5", 7310532109090L },
                    { "6", 7611612222105L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EANCampaign");
        }
    }
}
