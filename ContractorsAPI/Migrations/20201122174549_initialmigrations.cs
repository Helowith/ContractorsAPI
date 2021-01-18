using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractorsAPI.Migrations
{
    public partial class initialmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontrahenci",
                columns: table => new
                {
                    KontrahentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaFirmy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrKontaBankowego = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontrahenci", x => x.KontrahentID);
                });

            migrationBuilder.CreateTable(
                name: "Oddzialy",
                columns: table => new
                {
                    OddzialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CzyOddzialGlowny = table.Column<bool>(type: "bit", nullable: false),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wojewodztwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrBudynku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazwaOddzialu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontrahentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oddzialy", x => x.OddzialID);
                    table.ForeignKey(
                        name: "FK_Oddzialy_Kontrahenci_KontrahentID",
                        column: x => x.KontrahentID,
                        principalTable: "Kontrahenci",
                        principalColumn: "KontrahentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OsobyKontaktowe",
                columns: table => new
                {
                    OsobaKontaktowaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OddzialID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsobyKontaktowe", x => x.OsobaKontaktowaID);
                    table.ForeignKey(
                        name: "FK_OsobyKontaktowe_Oddzialy_OddzialID",
                        column: x => x.OddzialID,
                        principalTable: "Oddzialy",
                        principalColumn: "OddzialID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oddzialy_KontrahentID",
                table: "Oddzialy",
                column: "KontrahentID");

            migrationBuilder.CreateIndex(
                name: "IX_OsobyKontaktowe_OddzialID",
                table: "OsobyKontaktowe",
                column: "OddzialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OsobyKontaktowe");

            migrationBuilder.DropTable(
                name: "Oddzialy");

            migrationBuilder.DropTable(
                name: "Kontrahenci");
        }
    }
}
