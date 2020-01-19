using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SbdProjekto.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Magazyny",
                columns: table => new
                {
                    MagazynId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true),
                    Miasto = table.Column<string>(nullable: true),
                    KodPocztowy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazyny", x => x.MagazynId);
                });

            migrationBuilder.CreateTable(
                name: "Nadawcy",
                columns: table => new
                {
                    NadawcaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true),
                    Miasto = table.Column<string>(nullable: true),
                    KodPocztowy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nadawcy", x => x.NadawcaId);
                });

            migrationBuilder.CreateTable(
                name: "Odbiorcy",
                columns: table => new
                {
                    OdbiorcaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true),
                    Miasto = table.Column<string>(nullable: true),
                    KodPocztowy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odbiorcy", x => x.OdbiorcaId);
                });

            migrationBuilder.CreateTable(
                name: "Rejony",
                columns: table => new
                {
                    RejonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: true),
                    Wojewodztwo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rejony", x => x.RejonId);
                });

            migrationBuilder.CreateTable(
                name: "RodzajePrzesylek",
                columns: table => new
                {
                    RodzajPrzesylkiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(nullable: true),
                    Cena = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajePrzesylek", x => x.RodzajPrzesylkiId);
                });

            migrationBuilder.CreateTable(
                name: "Kurierzy",
                columns: table => new
                {
                    KurierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    Pesel = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    RejonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurierzy", x => x.KurierId);
                    table.ForeignKey(
                        name: "FK_Kurierzy_Rejony_RejonId",
                        column: x => x.RejonId,
                        principalTable: "Rejony",
                        principalColumn: "RejonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    ZamowienieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KurierId = table.Column<int>(nullable: false),
                    NadawcaId = table.Column<int>(nullable: false),
                    OdbiorcaId = table.Column<int>(nullable: false),
                    DataNadania = table.Column<DateTime>(nullable: false),
                    DataOdbioru = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.ZamowienieId);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Kurierzy_KurierId",
                        column: x => x.KurierId,
                        principalTable: "Kurierzy",
                        principalColumn: "KurierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Nadawcy_NadawcaId",
                        column: x => x.NadawcaId,
                        principalTable: "Nadawcy",
                        principalColumn: "NadawcaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Odbiorcy_OdbiorcaId",
                        column: x => x.OdbiorcaId,
                        principalTable: "Odbiorcy",
                        principalColumn: "OdbiorcaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Przesylki",
                columns: table => new
                {
                    PrzesylkaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Waga = table.Column<double>(nullable: false),
                    Szerokosc = table.Column<double>(nullable: false),
                    Wysokosc = table.Column<double>(nullable: false),
                    Dlugosc = table.Column<double>(nullable: false),
                    MagazynId = table.Column<int>(nullable: false),
                    RodzajPrzesylkiId = table.Column<int>(nullable: false),
                    ZamowienieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przesylki", x => x.PrzesylkaId);
                    table.ForeignKey(
                        name: "FK_Przesylki_Magazyny_MagazynId",
                        column: x => x.MagazynId,
                        principalTable: "Magazyny",
                        principalColumn: "MagazynId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Przesylki_RodzajePrzesylek_RodzajPrzesylkiId",
                        column: x => x.RodzajPrzesylkiId,
                        principalTable: "RodzajePrzesylek",
                        principalColumn: "RodzajPrzesylkiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Przesylki_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "ZamowienieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurierzy_RejonId",
                table: "Kurierzy",
                column: "RejonId");

            migrationBuilder.CreateIndex(
                name: "IX_Przesylki_MagazynId",
                table: "Przesylki",
                column: "MagazynId");

            migrationBuilder.CreateIndex(
                name: "IX_Przesylki_RodzajPrzesylkiId",
                table: "Przesylki",
                column: "RodzajPrzesylkiId");

            migrationBuilder.CreateIndex(
                name: "IX_Przesylki_ZamowienieId",
                table: "Przesylki",
                column: "ZamowienieId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_KurierId",
                table: "Zamowienia",
                column: "KurierId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_NadawcaId",
                table: "Zamowienia",
                column: "NadawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_OdbiorcaId",
                table: "Zamowienia",
                column: "OdbiorcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Przesylki");

            migrationBuilder.DropTable(
                name: "Magazyny");

            migrationBuilder.DropTable(
                name: "RodzajePrzesylek");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Kurierzy");

            migrationBuilder.DropTable(
                name: "Nadawcy");

            migrationBuilder.DropTable(
                name: "Odbiorcy");

            migrationBuilder.DropTable(
                name: "Rejony");
        }
    }
}
