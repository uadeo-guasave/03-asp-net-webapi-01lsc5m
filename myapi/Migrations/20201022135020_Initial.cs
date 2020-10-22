using Microsoft.EntityFrameworkCore.Migrations;

namespace myapi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "Users",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(nullable: false)
            //             .Annotation("Sqlite:Autoincrement", true),
            //         firstname = table.Column<string>(maxLength: 50, nullable: false),
            //         lastname = table.Column<string>(maxLength: 50, nullable: false),
            //         email = table.Column<string>(maxLength: 200, nullable: false),
            //         gender = table.Column<string>(maxLength: 6, nullable: false),
            //         name = table.Column<string>(maxLength: 20, nullable: false),
            //         password = table.Column<string>(maxLength: 12, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Users", x => x.id);
            //     });

            // migrationBuilder.CreateIndex(
            //     name: "IX_Users_email",
            //     table: "Users",
            //     column: "email",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_Users_name",
            //     table: "Users",
            //     column: "name",
            //     unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
