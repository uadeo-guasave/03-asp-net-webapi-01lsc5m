using Microsoft.EntityFrameworkCore.Migrations;

namespace myapi.Migrations
{
    public partial class CreateAuthorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstname = table.Column<string>(maxLength: 50, nullable: false),
                    lastname = table.Column<string>(maxLength: 50, nullable: false),
                    age = table.Column<int>(nullable: false),
                    email = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
