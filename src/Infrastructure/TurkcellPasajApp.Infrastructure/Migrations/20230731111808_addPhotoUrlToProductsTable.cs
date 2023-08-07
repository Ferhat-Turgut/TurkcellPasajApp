using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurkcellPasajApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPhotoUrlToProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Products");

            
        }
    }
}
