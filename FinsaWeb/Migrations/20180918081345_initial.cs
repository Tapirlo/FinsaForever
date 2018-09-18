using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinsaWeb.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aule",
                columns: table => new
                {
                    nomeaula = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    numerocomputer = table.Column<int>(nullable: false),
                    numeroposti = table.Column<int>(nullable: false),
                    superficie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aule", x => x.nomeaula);
                });

            migrationBuilder.CreateTable(
                name: "corsi",
                columns: table => new
                {
                    idcorso = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    datafine = table.Column<DateTime>(type: "datetime", nullable: false),
                    datainizio = table.Column<DateTime>(type: "datetime", nullable: false),
                    nome = table.Column<string>(unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corsi", x => x.idcorso);
                });

            migrationBuilder.CreateTable(
                name: "docenti",
                columns: table => new
                {
                    codicefiscale = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    cognome = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    datanascita = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    nome = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    telefono = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docenti", x => x.codicefiscale);
                });

            migrationBuilder.CreateTable(
                name: "studenti",
                columns: table => new
                {
                    codicefiscale = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    cognome = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    datanascita = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    nome = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    sesso = table.Column<string>(unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studenti", x => x.codicefiscale);
                });

            migrationBuilder.CreateTable(
                name: "materiecorsi",
                columns: table => new
                {
                    corso = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    materia = table.Column<string>(unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materiecorsi", x => new { x.corso, x.materia });
                    table.ForeignKey(
                        name: "FK__materieco__corso__3D5E1FD2",
                        column: x => x.corso,
                        principalTable: "corsi",
                        principalColumn: "idcorso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "prenotazioniaule",
                columns: table => new
                {
                    corso = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    aula = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    data = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prenotazioniaule", x => new { x.corso, x.aula, x.data });
                    table.ForeignKey(
                        name: "FK__svolgimen__nomea__46E78A0C",
                        column: x => x.aula,
                        principalTable: "aule",
                        principalColumn: "nomeaula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__svolgimen__idcor__45F365D3",
                        column: x => x.corso,
                        principalTable: "corsi",
                        principalColumn: "idcorso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "docenticorsi",
                columns: table => new
                {
                    corso = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    docente = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    punteggio = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docenticorsi", x => new { x.corso, x.docente });
                    table.ForeignKey(
                        name: "FK__docentico__idcor__403A8C7D",
                        column: x => x.corso,
                        principalTable: "corsi",
                        principalColumn: "idcorso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__docentico__docen__412EB0B6",
                        column: x => x.docente,
                        principalTable: "docenti",
                        principalColumn: "codicefiscale",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "insegnamenti",
                columns: table => new
                {
                    docente = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    materia = table.Column<string>(unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insegnamenti", x => new { x.docente, x.materia });
                    table.ForeignKey(
                        name: "FK__insegname__inseg__4D94879B",
                        column: x => x.docente,
                        principalTable: "docenti",
                        principalColumn: "codicefiscale",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "studenticorsi",
                columns: table => new
                {
                    corso = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    studente = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    punteggio = table.Column<int>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studenticorsi", x => new { x.corso, x.studente });
                    table.ForeignKey(
                        name: "FK__studentic__idcor__49C3F6B7",
                        column: x => x.corso,
                        principalTable: "corsi",
                        principalColumn: "idcorso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__studentic__stude__4AB81AF0",
                        column: x => x.studente,
                        principalTable: "studenti",
                        principalColumn: "codicefiscale",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_docenticorsi_docente",
                table: "docenticorsi",
                column: "docente");

            migrationBuilder.CreateIndex(
                name: "IX_prenotazioniaule_aula",
                table: "prenotazioniaule",
                column: "aula");

            migrationBuilder.CreateIndex(
                name: "IX_studenticorsi_studente",
                table: "studenticorsi",
                column: "studente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "docenticorsi");

            migrationBuilder.DropTable(
                name: "insegnamenti");

            migrationBuilder.DropTable(
                name: "materiecorsi");

            migrationBuilder.DropTable(
                name: "prenotazioniaule");

            migrationBuilder.DropTable(
                name: "studenticorsi");

            migrationBuilder.DropTable(
                name: "docenti");

            migrationBuilder.DropTable(
                name: "aule");

            migrationBuilder.DropTable(
                name: "corsi");

            migrationBuilder.DropTable(
                name: "studenti");
        }
    }
}
