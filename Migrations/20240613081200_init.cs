using System;
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
                name: "KVN",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SugarKV = table.Column<int>(type: "integer", nullable: false),
                    SugarN = table.Column<int>(type: "integer", nullable: false),
                    FlourKV = table.Column<int>(type: "integer", nullable: false),
                    FlourN = table.Column<int>(type: "integer", nullable: false),
                    EggsKV = table.Column<int>(type: "integer", nullable: false),
                    EggsN = table.Column<int>(type: "integer", nullable: false),
                    ButterKV = table.Column<int>(type: "integer", nullable: false),
                    ButterN = table.Column<int>(type: "integer", nullable: false),
                    ChocolateKV = table.Column<int>(type: "integer", nullable: false),
                    ChocolateN = table.Column<int>(type: "integer", nullable: false),
                    MilkKV = table.Column<int>(type: "integer", nullable: false),
                    MilkN = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KVN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SugarPrice = table.Column<float>(type: "real", nullable: false),
                    FlourPrice = table.Column<float>(type: "real", nullable: false),
                    EggsPrice = table.Column<float>(type: "real", nullable: false),
                    ButterPrice = table.Column<float>(type: "real", nullable: false),
                    ChocolatePrice = table.Column<float>(type: "real", nullable: false),
                    MilkPrice = table.Column<float>(type: "real", nullable: false)
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
                    Cookies = table.Column<float>(type: "real", nullable: false),
                    Sugar = table.Column<float>(type: "real", nullable: false),
                    Flour = table.Column<float>(type: "real", nullable: false),
                    Eggs = table.Column<float>(type: "real", nullable: false),
                    Butter = table.Column<float>(type: "real", nullable: false),
                    Chocolate = table.Column<float>(type: "real", nullable: false),
                    Milk = table.Column<float>(type: "real", nullable: false)
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
                name: "KVN");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
