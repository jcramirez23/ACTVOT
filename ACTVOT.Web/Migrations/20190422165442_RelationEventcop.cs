using Microsoft.EntityFrameworkCore.Migrations;

namespace ACTVOT.Web.Migrations
{
    public partial class RelationEventcop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_ActVotes_ActCandId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_ActCandId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ActCandId",
                table: "Candidates");

            migrationBuilder.AddColumn<int>(
                name: "ActCandId",
                table: "ActVotes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActVotes_ActCandId",
                table: "ActVotes",
                column: "ActCandId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActVotes_Candidates_ActCandId",
                table: "ActVotes",
                column: "ActCandId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActVotes_Candidates_ActCandId",
                table: "ActVotes");

            migrationBuilder.DropIndex(
                name: "IX_ActVotes_ActCandId",
                table: "ActVotes");

            migrationBuilder.DropColumn(
                name: "ActCandId",
                table: "ActVotes");

            migrationBuilder.AddColumn<int>(
                name: "ActCandId",
                table: "Candidates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ActCandId",
                table: "Candidates",
                column: "ActCandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_ActVotes_ActCandId",
                table: "Candidates",
                column: "ActCandId",
                principalTable: "ActVotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
