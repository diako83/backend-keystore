using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendkeystore.Migrations
{
    /// <inheritdoc />
    public partial class addUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_CampaignReceipts_CampaignReceiptId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_NormalPriceReceipt_NormalPriceReceiptId",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NormalPriceReceipt",
                table: "NormalPriceReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EANCampaign",
                table: "EANCampaign");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Receipts");

            migrationBuilder.RenameTable(
                name: "NormalPriceReceipt",
                newName: "NormalPriceReceipts");

            migrationBuilder.RenameTable(
                name: "EANCampaign",
                newName: "EANCampaigns");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_NormalPriceReceiptId",
                table: "Receipts",
                newName: "IX_Receipts_NormalPriceReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_CampaignReceiptId",
                table: "Receipts",
                newName: "IX_Receipts_CampaignReceiptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NormalPriceReceipts",
                table: "NormalPriceReceipts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EANCampaigns",
                table: "EANCampaigns",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_CampaignReceipts_CampaignReceiptId",
                table: "Receipts",
                column: "CampaignReceiptId",
                principalTable: "CampaignReceipts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_NormalPriceReceipts_NormalPriceReceiptId",
                table: "Receipts",
                column: "NormalPriceReceiptId",
                principalTable: "NormalPriceReceipts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_CampaignReceipts_CampaignReceiptId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_NormalPriceReceipts_NormalPriceReceiptId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NormalPriceReceipts",
                table: "NormalPriceReceipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EANCampaigns",
                table: "EANCampaigns");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "Receipt");

            migrationBuilder.RenameTable(
                name: "NormalPriceReceipts",
                newName: "NormalPriceReceipt");

            migrationBuilder.RenameTable(
                name: "EANCampaigns",
                newName: "EANCampaign");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_NormalPriceReceiptId",
                table: "Receipt",
                newName: "IX_Receipt_NormalPriceReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_CampaignReceiptId",
                table: "Receipt",
                newName: "IX_Receipt_CampaignReceiptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NormalPriceReceipt",
                table: "NormalPriceReceipt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EANCampaign",
                table: "EANCampaign",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_CampaignReceipts_CampaignReceiptId",
                table: "Receipt",
                column: "CampaignReceiptId",
                principalTable: "CampaignReceipts",
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
