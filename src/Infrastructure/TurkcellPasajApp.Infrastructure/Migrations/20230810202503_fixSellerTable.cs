using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurkcellPasajApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixSellerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sellers_SellerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SellerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SellerId",
                table: "OrderDetails",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Sellers_SellerId",
                table: "OrderDetails",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Sellers_SellerId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_SellerId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SellerId",
                table: "Orders",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sellers_SellerId",
                table: "Orders",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");
        }
    }
}
