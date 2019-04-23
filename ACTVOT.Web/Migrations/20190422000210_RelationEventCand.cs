using Microsoft.EntityFrameworkCore.Migrations;

namespace ACTVOT.Web.Migrations
{
    public partial class RelationEventCand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Candidates",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Polparty",
                table: "Candidates",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Candidates",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Polparty",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
