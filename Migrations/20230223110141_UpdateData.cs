using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backendkeystore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CampaignReceiptId", "EAN", "Name", "NormalPriceReceiptId", "Price" },
                values: new object[,]
                {
                    { 1, null, 5000112637922L, "Coca-cola", null, 19.949999999999999 },
                    { 2, null, 5000112637939L, "Sprite", null, 19.949999999999999 },
                    { 3, null, 7310865004703L, "Pepsi", null, 19.949999999999999 },
                    { 4, null, 7340005404261L, "Seven-upp", null, 19.949999999999999 },
                    { 5, null, 7310532109090L, "Fanta", null, 19.949999999999999 },
                    { 6, null, 5000112555922L, "Glass", null, 19.75 },
                    { 7, null, 5000112666622L, "Mjöl", null, 25.5 },
                    { 8, null, 5000112337922L, "Champo", null, 18.59 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
