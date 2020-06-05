using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_RB.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalcFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Insert_Date = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalcResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Insert_Date = table.Column<DateTimeOffset>(nullable: false),
                    Value = table.Column<string>(maxLength: 300, nullable: false),
                    CalcFunctionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalcResults_CalcFunctions_CalcFunctionId",
                        column: x => x.CalcFunctionId,
                        principalTable: "CalcFunctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CalcFunctions",
                columns: new[] { "Id", "Insert_Date" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2020, 6, 5, 13, 23, 26, 493, DateTimeKind.Unspecified).AddTicks(4385), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2020, 6, 5, 13, 23, 26, 493, DateTimeKind.Unspecified).AddTicks(7571), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2020, 6, 5, 13, 23, 26, 493, DateTimeKind.Unspecified).AddTicks(7645), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2020, 6, 5, 13, 23, 26, 493, DateTimeKind.Unspecified).AddTicks(7653), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalcResults_CalcFunctionId",
                table: "CalcResults",
                column: "CalcFunctionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalcResults");

            migrationBuilder.DropTable(
                name: "CalcFunctions");
        }
    }
}
