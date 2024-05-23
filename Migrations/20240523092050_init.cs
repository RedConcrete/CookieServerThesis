using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    SugarPrice = table.Column<int>(type: "integer", nullable: false),
                    FlourPrice = table.Column<int>(type: "integer", nullable: false),
                    EggsPrice = table.Column<int>(type: "integer", nullable: false),
                    ButterPrice = table.Column<int>(type: "integer", nullable: false),
                    ChocolatePrice = table.Column<int>(type: "integer", nullable: false),
                    MilkPrice = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Cookies = table.Column<int>(type: "integer", nullable: false),
                    Sugar = table.Column<int>(type: "integer", nullable: false),
                    Flour = table.Column<int>(type: "integer", nullable: false),
                    Eggs = table.Column<int>(type: "integer", nullable: false),
                    Butter = table.Column<int>(type: "integer", nullable: false),
                    Chocolate = table.Column<int>(type: "integer", nullable: false),
                    Milk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
