using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmployeeForms.Migrations
{
    /// <inheritdoc />
    public partial class ImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departmentList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DeptCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    DeptName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    DeptLocation = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departmentList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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
                    AccountNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    IFSCCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Branch = table.Column<string>(type: "longtext", nullable: false),
                    BankName = table.Column<string>(type: "longtext", nullable: false),
                    AccountType = table.Column<string>(type: "longtext", nullable: false),
                    AddresssLine1 = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    State = table.Column<string>(type: "longtext", nullable: false),
                    Pincode = table.Column<string>(type: "longtext", nullable: false),
                    ImageURL = table.Column<string>(type: "longtext", maxLength: 2097152, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesSetList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employeesSetList_departmentList_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departmentList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_employeesSetList_DepartmentId",
                table: "employeesSetList",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeesSetList");

            migrationBuilder.DropTable(
                name: "departmentList");
        }
    }
}
