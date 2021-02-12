using Microsoft.EntityFrameworkCore.Migrations;

namespace EnsatProject.Migrations.Data
{
    public partial class fkbug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Eleve_EnsatProjectUserId",
                table: "Eleve",
                column: "EnsatProjectUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eleve_EnsatProjectUser_EnsatProjectUserId",
                table: "Eleve",
                column: "EnsatProjectUserId",
                principalTable: "EnsatProjectUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eleve_EnsatProjectUser_EnsatProjectUserId",
                table: "Eleve");

            migrationBuilder.DropIndex(
                name: "IX_Eleve_EnsatProjectUserId",
                table: "Eleve");
        }
    }
}
