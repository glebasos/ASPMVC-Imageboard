using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCh.Migrations
{
    public partial class imgsupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Images_PostImageId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostImageId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostImageId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Images",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PostId",
                table: "Images",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Posts_PostId",
                table: "Images",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Posts_PostId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PostId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "PostImageId",
                table: "Posts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostImageId",
                table: "Posts",
                column: "PostImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Images_PostImageId",
                table: "Posts",
                column: "PostImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
