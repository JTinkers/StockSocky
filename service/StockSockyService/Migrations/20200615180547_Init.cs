using Microsoft.EntityFrameworkCore.Migrations;

namespace StockSockyService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StockId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Symbol" },
                values: new object[] { 1, "HTZ" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Symbol" },
                values: new object[] { 2, "AAA" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Symbol" },
                values: new object[] { 3, "OAS" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Quantity", "StockId", "Value" },
                values: new object[] { 1, 15, 1, 1.45 });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Quantity", "StockId", "Value" },
                values: new object[] { 2, 5, 1, 1.8999999999999999 });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Quantity", "StockId", "Value" },
                values: new object[] { 3, 26, 2, 2.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_StockId",
                table: "Purchases",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
