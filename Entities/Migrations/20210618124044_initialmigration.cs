using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingradients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngradientId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Prize = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingradients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaDetails",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PizzaPic = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PizzaPrize = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaDetails", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "PizzaOrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    FinalPrize = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrderDetails", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngradients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngradientId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Prize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngradients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaIngradients_PizzaDetails_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "PizzaDetails",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngradientOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Prize = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngradientOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaIngradientOrderDetails_PizzaOrderDetails_OrderId",
                        column: x => x.OrderId,
                        principalTable: "PizzaOrderDetails",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngradientOrderDetails_OrderId",
                table: "PizzaIngradientOrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngradients_PizzaId",
                table: "PizzaIngradients",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingradients");

            migrationBuilder.DropTable(
                name: "PizzaIngradientOrderDetails");

            migrationBuilder.DropTable(
                name: "PizzaIngradients");

            migrationBuilder.DropTable(
                name: "PizzaOrderDetails");

            migrationBuilder.DropTable(
                name: "PizzaDetails");
        }
    }
}
