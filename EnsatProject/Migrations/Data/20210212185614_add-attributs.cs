using Microsoft.EntityFrameworkCore.Migrations;

namespace EnsatProject.Migrations.Data
{
    public partial class addattributs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnseignantId",
                table: "Seance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seance_EnseignantId",
                table: "Seance",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignant_EnsatProjectUserId",
                table: "Enseignant",
                column: "EnsatProjectUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enseignant_EnsatProjectUser_EnsatProjectUserId",
                table: "Enseignant",
                column: "EnsatProjectUserId",
                principalTable: "EnsatProjectUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_Enseignant_EnseignantId",
                table: "Seance",
                column: "EnseignantId",
                principalTable: "Enseignant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enseignant_EnsatProjectUser_EnsatProjectUserId",
                table: "Enseignant");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_Enseignant_EnseignantId",
                table: "Seance");

            migrationBuilder.DropIndex(
                name: "IX_Seance_EnseignantId",
                table: "Seance");

            migrationBuilder.DropIndex(
                name: "IX_Enseignant_EnsatProjectUserId",
                table: "Enseignant");

            migrationBuilder.DropColumn(
                name: "EnseignantId",
                table: "Seance");
        }
    }
}
