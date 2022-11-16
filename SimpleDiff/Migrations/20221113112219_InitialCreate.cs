using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleDiff.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiffItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiffItems", x => new { x.Id, x.Type });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiffItems");
        }
    }
}
