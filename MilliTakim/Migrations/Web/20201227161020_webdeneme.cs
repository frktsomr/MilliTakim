using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilliTakim.Migrations.Web
{
    public partial class webdeneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "futbolcu",
                columns: table => new
                {
                    playerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    futbolcuAd = table.Column<string>(nullable: false),
                    futbolcuSoyad = table.Column<string>(nullable: false),
                    futbolcuInsta = table.Column<string>(nullable: true),
                    futbolcuTwitter = table.Column<string>(nullable: true),
                    futbolcuYas = table.Column<int>(nullable: false),
                    futbolcuMarketDegeri = table.Column<long>(nullable: false),
                    ProfilePicture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_futbolcu", x => x.playerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "futbolcu");
        }
    }
}
