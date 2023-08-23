using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobQPractices.Migrations
{
    /// <inheritdoc />
    public partial class sqlite_migration_327 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    JobStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "jobDetails",
                columns: new[] { "Id", "Description", "FinishDate", "JobStatus" },
                values: new object[,]
                {
                    { "1", "first job", new DateTime(2023, 8, 23, 11, 27, 19, 66, DateTimeKind.Local).AddTicks(1919), 0 },
                    { "2", "second job", new DateTime(2023, 8, 23, 11, 27, 19, 66, DateTimeKind.Local).AddTicks(1940), 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobDetails");
        }
    }
}
