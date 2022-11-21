using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.DLL.Migrations
{
    /// <inheritdoc />
    public partial class CreateCountingDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countingDatas",
                columns: table => new
                {
                    CountingDataId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ToTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalCount = table.Column<int>(type: "integer", nullable: false),
                    JoCount = table.Column<int>(type: "integer", nullable: false),
                    RepedtCount = table.Column<int>(type: "integer", nullable: false),
                    OlajosCount = table.Column<int>(type: "integer", nullable: false),
                    TorottSzelCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countingDatas", x => x.CountingDataId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "countingDatas");
        }
    }
}
