using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumbersToEnglishProcessed",
                columns: table => new
                {
                    NumberToEnglishHistoryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputNumber = table.Column<decimal>(type: "DECIMAL(12,12)", nullable: false),
                    OutputText = table.Column<string>(unicode: false, maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumbersToEnglishProcessed", x => x.NumberToEnglishHistoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumbersToEnglishProcessed");
        }
    }
}
