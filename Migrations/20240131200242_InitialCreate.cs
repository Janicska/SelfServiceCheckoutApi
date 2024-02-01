using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfServiceCheckoutApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HUF5 = table.Column<int>(type: "INTEGER", nullable: false),
                    HUF10 = table.Column<int>(type: "INTEGER", nullable: false),
                    HUF20 = table.Column<int>(type: "INTEGER", nullable: false),
                    HUF50 = table.Column<int>(type: "INTEGER", nullable: false),
                    HUF100 = table.Column<int>(type: "INTEGER", nullable: false),
                    HUF200 = table.Column<int>(type: "INTEGER", nullable: false),
                    HUF500 = table.Column<int>(type: "INTEGER", nullable: false),
                    HUF1000 = table.Column<int>(type: "INTEGER", nullable: false),
                    HUF2000 = table.Column<int>(type: "INTEGER", nullable: false),
                    HUF5000 = table.Column<int>(type: "INTEGER", nullable: false),
                    HUF10000 = table.Column<int>(type: "INTEGER", nullable: false),
                    HUF20000 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
