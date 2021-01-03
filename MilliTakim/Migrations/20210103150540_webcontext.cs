using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilliTakim.Migrations
{
    public partial class webcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bilet",
                columns: table => new
                {
                    biletId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    macAdi = table.Column<string>(nullable: false),
                    biletFiyat = table.Column<int>(nullable: false),
                    biletAdet = table.Column<int>(nullable: false),
                    macYer = table.Column<string>(nullable: false),
                    macTarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bilet", x => x.biletId);
                });

            migrationBuilder.CreateTable(
                name: "futbolcu",
                columns: table => new
                {
                    playerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    futbolcuAd = table.Column<string>(maxLength: 20, nullable: false),
                    futbolcuSoyad = table.Column<string>(maxLength: 20, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "magaza",
                columns: table => new
                {
                    urunId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urunAdi = table.Column<string>(nullable: false),
                    fiyat = table.Column<int>(nullable: false),
                    beden = table.Column<int>(nullable: false),
                    ProfilePicture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_magaza", x => x.urunId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bilet");

            migrationBuilder.DropTable(
                name: "futbolcu");

            migrationBuilder.DropTable(
                name: "magaza");
        }
    }
}
