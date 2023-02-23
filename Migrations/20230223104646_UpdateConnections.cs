using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendkeystore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_CampaignReceipt_CampaignReceiptId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_NormalPriceReceipt_NormalPriceReceiptId",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_CampaignReceiptId",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_NormalPriceReceiptId",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "CampaignReceiptId",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "NormalPriceReceiptId",
                table: "Receipt");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "NormalPriceReceipt",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "CampaignReceipt",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NormalPriceReceipt_ReceiptId",
                table: "NormalPriceReceipt",
                column: "ReceiptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignReceipt_ReceiptId",
                table: "CampaignReceipt",
                column: "ReceiptId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignReceipt_Receipt_ReceiptId",
                table: "CampaignReceipt",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NormalPriceReceipt_Receipt_ReceiptId",
                table: "NormalPriceReceipt",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignReceipt_Receipt_ReceiptId",
                table: "CampaignReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_NormalPriceReceipt_Receipt_ReceiptId",
                table: "NormalPriceReceipt");

            migrationBuilder.DropIndex(
                name: "IX_NormalPriceReceipt_ReceiptId",
                table: "NormalPriceReceipt");

            migrationBuilder.DropIndex(
                name: "IX_CampaignReceipt_ReceiptId",
                table: "CampaignReceipt");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "NormalPriceReceipt");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "CampaignReceipt");

            migrationBuilder.AddColumn<int>(
                name: "CampaignReceiptId",
                table: "Receipt",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NormalPriceReceiptId",
                table: "Receipt",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_CampaignReceiptId",
                table: "Receipt",
                column: "CampaignReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_NormalPriceReceiptId",
                table: "Receipt",
                column: "NormalPriceReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_CampaignReceipt_CampaignReceiptId",
                table: "Receipt",
                column: "CampaignReceiptId",
                principalTable: "CampaignReceipt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_NormalPriceReceipt_NormalPriceReceiptId",
                table: "Receipt",
                column: "NormalPriceReceiptId",
                principalTable: "NormalPriceReceipt",
                principalColumn: "Id");
        }
    }
}
