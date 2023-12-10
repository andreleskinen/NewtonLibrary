using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class Library16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorLastName",
                table: "Authors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "AuthorFirstName",
                table: "Authors",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Authors",
                newName: "AuthorLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Authors",
                newName: "AuthorFirstName");
        }
    }
}
