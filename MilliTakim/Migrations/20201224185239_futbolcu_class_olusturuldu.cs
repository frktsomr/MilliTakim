using Microsoft.EntityFrameworkCore.Migrations;

namespace MilliTakim.Migrations
{
    public partial class futbolcu_class_olusturuldu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "futbolcu",
                columns: table => new
                {
                    playerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
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
