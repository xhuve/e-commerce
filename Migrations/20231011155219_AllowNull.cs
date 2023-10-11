using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class AllowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderItems_OrderListid",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "OrderListid",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderItems_OrderListid",
                table: "Products",
                column: "OrderListid",
                principalTable: "OrderItems",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderItems_OrderListid",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "OrderListid",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderItems_OrderListid",
                table: "Products",
                column: "OrderListid",
                principalTable: "OrderItems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
