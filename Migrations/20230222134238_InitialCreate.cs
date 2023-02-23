using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backendkeystore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignReceipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignReceipt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NormalPriceReceipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalPriceReceipt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EAN = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CampaignReceiptId = table.Column<int>(type: "integer", nullable: true),
                    NormalPriceReceiptId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_CampaignReceipt_CampaignReceiptId",
                        column: x => x.CampaignReceiptId,
                        principalTable: "CampaignReceipt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_NormalPriceReceipt_NormalPriceReceiptId",
                        column: x => x.NormalPriceReceiptId,
                        principalTable: "NormalPriceReceipt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CampaignReceiptId = table.Column<int>(type: "integer", nullable: true),
                    NormalPriceReceiptId = table.Column<int>(type: "integer", nullable: true),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_CampaignReceipt_CampaignReceiptId",
                        column: x => x.CampaignReceiptId,
                        principalTable: "CampaignReceipt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receipt_NormalPriceReceipt_NormalPriceReceiptId",
                        column: x => x.NormalPriceReceiptId,
                        principalTable: "NormalPriceReceipt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CampaignReceiptId",
                table: "Product",
                column: "CampaignReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_NormalPriceReceiptId",
                table: "Product",
                column: "NormalPriceReceiptId");

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
                name: "Product");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "CampaignReceipt");

            migrationBuilder.DropTable(
                name: "NormalPriceReceipt");
        }
    }
}
