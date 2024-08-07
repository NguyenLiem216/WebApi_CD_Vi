using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Tutorial_ProductManager.Migrations
{
    public partial class AddTableProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Type",
                table: "ProductManager",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Products_Type",
                columns: table => new
                {
                    Id_Type = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Type", x => x.Id_Type);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductManager_Id_Type",
                table: "ProductManager",
                column: "Id_Type");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManager_Products_Type_Id_Type",
                table: "ProductManager",
                column: "Id_Type",
                principalTable: "Products_Type",
                principalColumn: "Id_Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductManager_Products_Type_Id_Type",
                table: "ProductManager");

            migrationBuilder.DropTable(
                name: "Products_Type");

            migrationBuilder.DropIndex(
                name: "IX_ProductManager_Id_Type",
                table: "ProductManager");

            migrationBuilder.DropColumn(
                name: "Id_Type",
                table: "ProductManager");
        }
    }
}
