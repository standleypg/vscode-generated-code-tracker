using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleTables");

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
                name: "USERS",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    USER_EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PASSWORD_HASH = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PASSWORD_SALT = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    USER_IMAGE = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "MAIN_USER_STATS",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROJECT_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SOLUTION_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NOOF_AUTO_GEN_LINES = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAIN_USER_STATS", x => new { x.USER_ID, x.PROJECT_ID, x.SOLUTION_ID });
                    table.ForeignKey(
                        name: "FK_MAIN_USER_STATS_PROJECTS_LIST_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalTable: "PROJECTS_LIST",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MAIN_USER_STATS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_PROJECTS_USERS_PROJECTS_LIST_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalTable: "PROJECTS_LIST",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJECTS_USERS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_RECORDS",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SOLUTION_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SEQ_NO = table.Column<int>(type: "int", nullable: false),
                    RECORD_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOOF_AUTO_GEN_LINES = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_RECORDS", x => new { x.USER_ID, x.SOLUTION_ID, x.SEQ_NO });
                    table.ForeignKey(
                        name: "FK_USER_RECORDS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MAIN_USER_STATS_PROJECT_ID",
                table: "MAIN_USER_STATS",
                column: "PROJECT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTS_USERS_USER_ID",
                table: "PROJECTS_USERS",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MAIN_USER_STATS");

            migrationBuilder.DropTable(
                name: "PROJECTS_USERS");

            migrationBuilder.DropTable(
                name: "USER_RECORDS");

            migrationBuilder.DropTable(
                name: "PROJECTS_LIST");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.CreateTable(
                name: "SampleTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTables", x => x.Id);
                });
        }
    }
}
