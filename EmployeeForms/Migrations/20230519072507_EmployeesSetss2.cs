using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmployeeForms.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesSetss2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeesSetList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    EmployeeCode = table.Column<string>(type: "longtext", nullable: false),
                    Gender = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    BloodGroup = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    AccountNo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    IFSCCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Branch = table.Column<string>(type: "longtext", nullable: false),
                    AddresssLine1 = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    State = table.Column<string>(type: "longtext", nullable: false),
                    Pincode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesSetList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeesSetList");
        }
    }
}