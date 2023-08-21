using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "shiv khera", "Complete CPP programming", "shiv khera", 100.0, 500.0, 1500.0, 1000.0, "CPP" },
                    { 2, "shiv khera", "Complete JAVA programming", "shiv khera", 200.0, 600.0, 1700.0, 1100.0, "JAVA" },
                    { 3, "shiv khera", "Complete C# programming", "shiv khera", 250.0, 650.0, 1750.0, 1150.0, "C#" },
                    { 4, "shiv khera", "Complete DOT NET programming", "shiv khera", 350.0, 750.0, 1850.0, 1250.0, "DOT NET" },
                    { 5, "shiv khera", "Complete C# programming", "shiv khera", 350.0, 750.0, 1950.0, 1250.0, "C#" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
