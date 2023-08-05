using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiorello2.Migrations
{
    public partial class AddIsDeactiveColumnToSliderImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeactive",
                table: "SliderImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeactive",
                table: "SliderImages");
        }
    }
}
