using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ceramics.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ColorName",
                table: "Color",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorFamID",
                table: "Color",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColorFamilyID",
                table: "Color",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chemistry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChemComp = table.Column<string>(maxLength: 255, nullable: false),
                    ChemAbbrev = table.Column<string>(maxLength: 50, nullable: false),
                    ColorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chemistry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ColorFamily",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorFamID = table.Column<int>(nullable: false),
                    ColorFam = table.Column<string>(maxLength: 50, nullable: false),
                    ColorName = table.Column<string>(maxLength: 50, nullable: false),
                    ColorID = table.Column<int>(nullable: false),
                    ChemID = table.Column<int>(nullable: true),
                    ChemAdminID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorFamily", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ColorFamily_Chemistry_ChemAdminID",
                        column: x => x.ChemAdminID,
                        principalTable: "Chemistry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Color_ColorFamilyID",
                table: "Color",
                column: "ColorFamilyID");

            migrationBuilder.CreateIndex(
                name: "IX_ColorFamily_ChemAdminID",
                table: "ColorFamily",
                column: "ChemAdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_ColorFamily_ColorFamilyID",
                table: "Color",
                column: "ColorFamilyID",
                principalTable: "ColorFamily",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_ColorFamily_ColorFamilyID",
                table: "Color");

            migrationBuilder.DropTable(
                name: "ColorFamily");

            migrationBuilder.DropTable(
                name: "Chemistry");

            migrationBuilder.DropIndex(
                name: "IX_Color_ColorFamilyID",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ColorFamID",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ColorFamilyID",
                table: "Color");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ColorName",
                table: "Color",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
