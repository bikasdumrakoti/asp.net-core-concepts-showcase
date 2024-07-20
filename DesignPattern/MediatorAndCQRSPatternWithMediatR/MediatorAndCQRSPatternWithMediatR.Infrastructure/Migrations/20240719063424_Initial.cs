using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediatorAndCQRSPatternWithMediatR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Shelly Marshall" },
                    { 2, "Christine Soto" },
                    { 3, "Angela Mcpherson" },
                    { 4, "David Quinn" },
                    { 5, "Yvonne Mccoy" },
                    { 6, "Samantha Webb" },
                    { 7, "Karina Clay" },
                    { 8, "Frank Davidson" },
                    { 9, "Haley Tate" },
                    { 10, "Stacey Sawyer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
