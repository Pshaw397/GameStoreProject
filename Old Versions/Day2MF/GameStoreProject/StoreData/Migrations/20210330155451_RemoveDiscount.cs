using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreData.Migrations
{
    public partial class RemoveDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "saleDiscount",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "saleDiscount",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
