using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.DLL.Migrations
{
    /// <inheritdoc />
    public partial class CreateStatDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "statDatas",
                columns: table => new
                {
                    StatDataId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    FromTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ToTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HibaSum = table.Column<int>(type: "integer", nullable: false),
                    JoSum = table.Column<int>(type: "integer", nullable: false),
                    RepedtSum = table.Column<int>(type: "integer", nullable: false),
                    OlajosSum = table.Column<int>(type: "integer", nullable: false),
                    TorottszelSum = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statDatas", x => x.StatDataId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "statDatas");
        }
    }
}
