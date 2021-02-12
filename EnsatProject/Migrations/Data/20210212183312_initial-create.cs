using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnsatProject.Migrations.Data
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnsatProjectUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsatProjectUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnsatProjectUserId = table.Column<int>(type: "int", nullable: true),
                    MyRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filiere",
                columns: table => new
                {
                    FiliereId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomFiliere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChefFiliereId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiere", x => x.FiliereId);
                    table.ForeignKey(
                        name: "FK_Filiere_Enseignant_ChefFiliereId",
                        column: x => x.ChefFiliereId,
                        principalTable: "Enseignant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoordinateurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleId);
                    table.ForeignKey(
                        name: "FK_Module_Enseignant_CoordinateurId",
                        column: x => x.CoordinateurId,
                        principalTable: "Enseignant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Eleve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnsatProjectUserId = table.Column<int>(type: "int", nullable: true),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyRole = table.Column<int>(type: "int", nullable: false),
                    FiliereId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eleve_Filiere_FiliereId",
                        column: x => x.FiliereId,
                        principalTable: "Filiere",
                        principalColumn: "FiliereId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    MatiereId = table.Column<int>(type: "int", nullable: false),
                    NomMatiere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeuresCours = table.Column<float>(type: "real", nullable: false),
                    HeuresTD = table.Column<float>(type: "real", nullable: false),
                    HeuresTP = table.Column<float>(type: "real", nullable: false),
                    FiliereId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.MatiereId);
                    table.ForeignKey(
                        name: "FK_Matiere_Filiere_FiliereId",
                        column: x => x.FiliereId,
                        principalTable: "Filiere",
                        principalColumn: "FiliereId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matiere_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignment",
                columns: table => new
                {
                    EnseignantId = table.Column<int>(type: "int", nullable: false),
                    MatiereId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignment", x => new { x.MatiereId, x.EnseignantId });
                    table.ForeignKey(
                        name: "FK_CourseAssignment_Enseignant_EnseignantId",
                        column: x => x.EnseignantId,
                        principalTable: "Enseignant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssignment_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "Matiere",
                        principalColumn: "MatiereId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valeur = table.Column<float>(type: "real", nullable: false),
                    MatiereId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    EleveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Eleve_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Note_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "Matiere",
                        principalColumn: "MatiereId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seance",
                columns: table => new
                {
                    SeanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatiereId = table.Column<int>(type: "int", nullable: true),
                    DebutSeance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinSeance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance", x => x.SeanceId);
                    table.ForeignKey(
                        name: "FK_Seance_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "Matiere",
                        principalColumn: "MatiereId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EleveId = table.Column<int>(type: "int", nullable: true),
                    MatiereId = table.Column<int>(type: "int", nullable: true),
                    NoteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollment_Eleve_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollment_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "Matiere",
                        principalColumn: "MatiereId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollment_Note_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Note",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Absence",
                columns: table => new
                {
                    AbsenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EleveId = table.Column<int>(type: "int", nullable: true),
                    SeanceId = table.Column<int>(type: "int", nullable: true),
                    Absent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.AbsenceId);
                    table.ForeignKey(
                        name: "FK_Absence_Eleve_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Absence_Seance_SeanceId",
                        column: x => x.SeanceId,
                        principalTable: "Seance",
                        principalColumn: "SeanceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absence_EleveId",
                table: "Absence",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_SeanceId",
                table: "Absence",
                column: "SeanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignment_EnseignantId",
                table: "CourseAssignment",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Eleve_FiliereId",
                table: "Eleve",
                column: "FiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_EleveId",
                table: "Enrollment",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_MatiereId",
                table: "Enrollment",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_NoteId",
                table: "Enrollment",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Filiere_ChefFiliereId",
                table: "Filiere",
                column: "ChefFiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_FiliereId",
                table: "Matiere",
                column: "FiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_ModuleId",
                table: "Matiere",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_CoordinateurId",
                table: "Module",
                column: "CoordinateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_EleveId",
                table: "Note",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_MatiereId",
                table: "Note",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_MatiereId",
                table: "Seance",
                column: "MatiereId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absence");

            migrationBuilder.DropTable(
                name: "CourseAssignment");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "EnsatProjectUser");

            migrationBuilder.DropTable(
                name: "Seance");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Eleve");

            migrationBuilder.DropTable(
                name: "Matiere");

            migrationBuilder.DropTable(
                name: "Filiere");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Enseignant");
        }
    }
}
