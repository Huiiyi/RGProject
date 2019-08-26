using Microsoft.EntityFrameworkCore.Migrations;

namespace RGProject.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Gold = table.Column<int>(nullable: false),
                    STR = table.Column<int>(nullable: false),
                    DEX = table.Column<int>(nullable: false),
                    Lucky = table.Column<int>(nullable: false),
                    DayCheck = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
