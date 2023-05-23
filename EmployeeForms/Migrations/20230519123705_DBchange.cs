using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeForms.Migrations
{
    /// <inheritdoc />
    public partial class DBchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "employeesSetList",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "employeesSetList",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "employeesSetList");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "employeesSetList");
        }
    }
}
