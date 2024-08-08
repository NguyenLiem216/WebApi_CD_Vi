using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Tutorial_ProductManager.Migrations
{
    public partial class AddOrderSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id_Ord = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now() AT TIME ZONE 'UTC'"),
                    DelDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OrdStatus = table.Column<int>(type: "integer", nullable: false),
                    Receiver = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ReceiverAddress = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id_Ord);
                });

            migrationBuilder.CreateTable(
                name: "Detailed_Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Id_Ord = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detailed_Orders", x => new { x.Id, x.Id_Ord });
                    table.ForeignKey(
                        name: "FK_Detail_Orders_Order",
                        column: x => x.Id_Ord,
                        principalTable: "Order",
                        principalColumn: "Id_Ord",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detail_Orders_Product",
                        column: x => x.Id,
                        principalTable: "ProductManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detailed_Orders_Id_Ord",
                table: "Detailed_Orders",
                column: "Id_Ord");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detailed_Orders");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
