using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderList_Products_Productsproduct_id",
                table: "OrderList");

            migrationBuilder.DropIndex(
                name: "IX_OrderList_Productsproduct_id",
                table: "OrderList");

            migrationBuilder.DropColumn(
                name: "Productsproduct_id",
                table: "OrderList");

            migrationBuilder.AddColumn<int>(
                name: "order_list_id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_order_list_id",
                table: "Products",
                column: "order_list_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderList_order_list_id",
                table: "Products",
                column: "order_list_id",
                principalTable: "OrderList",
                principalColumn: "order_items_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderList_order_list_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_order_list_id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "order_list_id",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Productsproduct_id",
                table: "OrderList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderList_Productsproduct_id",
                table: "OrderList",
                column: "Productsproduct_id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderList_Products_Productsproduct_id",
                table: "OrderList",
                column: "Productsproduct_id",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
