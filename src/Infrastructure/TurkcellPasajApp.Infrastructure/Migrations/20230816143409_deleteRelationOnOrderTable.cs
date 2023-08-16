using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurkcellPasajApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteRelationOnOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
