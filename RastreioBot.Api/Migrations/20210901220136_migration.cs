using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RastreioBot.Api.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tracking",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tracking_number = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    chat_id = table.Column<string>(type: "TEXT", nullable: true),
                    delivered = table.Column<bool>(type: "INTEGER", nullable: false),
                    create_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_update = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracking", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tracking");
        }
    }
}
