using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backendkeystore.Migrations
{
    /// <inheritdoc />
    public partial class ProductToStringConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignReceipts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    ProductIds = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignReceipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EANCampaign",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CampaignEan = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EANCampaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NormalPriceReceipt",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    ProductIds = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalPriceReceipt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Ean = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CampaignReceiptId = table.Column<string>(type: "text", nullable: true),
                    NormalPriceReceiptId = table.Column<string>(type: "text", nullable: true),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_CampaignReceipts_CampaignReceiptId",
                        column: x => x.CampaignReceiptId,
                        principalTable: "CampaignReceipts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receipt_NormalPriceReceipt_NormalPriceReceiptId",
                        column: x => x.NormalPriceReceiptId,
                        principalTable: "NormalPriceReceipt",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "EANCampaign",
                columns: new[] { "Id", "CampaignEan" },
                values: new object[,]
                {
                    { "1", 5000112637922L },
                    { "2", 5000112637939L },
                    { "3", 7310865004703L },
                    { "4", 7340005404261L },
                    { "5", 7310532109090L },
                    { "6", 7611612222105L }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Ean", "Name", "Price" },
                values: new object[,]
                {
                    { "1", 5000112637922L, "Coca-cola", 19.949999999999999 },
                    { "2", 5000112637939L, "Sprite", 19.949999999999999 },
                    { "3", 7310865004703L, "Pepsi", 19.949999999999999 },
                    { "4", 7340005404261L, "Seven-upp", 19.949999999999999 },
                    { "5", 7310532109090L, "Fanta", 19.949999999999999 },
                    { "6", 5000112555922L, "Glass", 19.75 },
                    { "7", 5000112666622L, "Mjöl", 25.5 },
                    { "8", 5000112337922L, "Champo", 18.59 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_CampaignReceiptId",
                table: "Receipt",
                column: "CampaignReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_NormalPriceReceiptId",
                table: "Receipt",
                column: "NormalPriceReceiptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EANCampaign");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "CampaignReceipts");

            migrationBuilder.DropTable(
                name: "NormalPriceReceipt");
        }
    }
}
