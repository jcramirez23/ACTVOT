using Microsoft.EntityFrameworkCore.Migrations;

namespace ACTVOT.Web.Migrations
{
    public partial class RelationE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Candidates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Candidates");
        }
    }
}
