using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurkcellPasajApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixRelationOrderDetailsAndSellersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsSellerId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderDetailsSellerId",
                table: "OrderDetails",
                column: "OrderDetailsSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Sellers_OrderDetailsSellerId",
                table: "OrderDetails",
                column: "OrderDetailsSellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Sellers_OrderDetailsSellerId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderDetailsSellerId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderDetailsSellerId",
                table: "OrderDetails");
        }
    }
}
