using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCh.Migrations
{
    public partial class changedImageagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageTitle",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageTitle",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
