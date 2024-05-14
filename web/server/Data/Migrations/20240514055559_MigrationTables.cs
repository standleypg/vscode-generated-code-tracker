using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MAIN_USER_STATS",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SolutionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NoOfAutoGenLines = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAIN_USER_STATS", x => new { x.UserId, x.ProjectId, x.SolutionId });
                });

            migrationBuilder.CreateTable(
                name: "PROJECTS_LIST",
                columns: table => new
                {
                    PROJECT_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PROJECT_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTS_LIST", x => x.PROJECT_ID);
                });

            migrationBuilder.CreateTable(
                name: "PROJECTS_USERS",
                columns: table => new
                {
                    PROJECT_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTS_USERS", x => new { x.PROJECT_ID, x.USER_ID });
                });

            migrationBuilder.CreateTable(
                name: "USER_RECORDS",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SOLUTION_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SEQ_NO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECORD_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOOF_AUTO_GEN_LINES = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_RECORDS", x => new { x.USER_ID, x.SOLUTION_ID, x.SEQ_NO });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MAIN_USER_STATS");

            migrationBuilder.DropTable(
                name: "PROJECTS_LIST");

            migrationBuilder.DropTable(
                name: "PROJECTS_USERS");

            migrationBuilder.DropTable(
                name: "USER_RECORDS");
        }
    }
}
