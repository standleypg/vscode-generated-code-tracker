using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorDBStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MAIN_USER_STATS");

            migrationBuilder.DropTable(
                name: "PROJECTS_USERS");

            migrationBuilder.DropTable(
                name: "USER_RECORDS");

            migrationBuilder.DropTable(
                name: "PROJECTS_LIST");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USERS",
                table: "USERS");

            migrationBuilder.RenameTable(
                name: "USERS",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "USER_NAME",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "USER_IMAGE",
                table: "Users",
                newName: "UserImage");

            migrationBuilder.RenameColumn(
                name: "USER_EMAIL",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "PASSWORD_SALT",
                table: "Users",
                newName: "PasswordSalt");

            migrationBuilder.RenameColumn(
                name: "PASSWORD_HASH",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                columns: new[] { "Id", "UserEmail" });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolutionUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceCodeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solutions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProjects_Users_UserId_UserEmail",
                        columns: x => new { x.UserId, x.UserEmail },
                        principalTable: "Users",
                        principalColumns: new[] { "Id", "UserEmail" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfGeneratedLines = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stats_Solutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stats_Users_UserId_UserEmail",
                        columns: x => new { x.UserId, x.UserEmail },
                        principalTable: "Users",
                        principalColumns: new[] { "Id", "UserEmail" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_ProjectId",
                table: "Solutions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_ProjectId",
                table: "Stats",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_SolutionId",
                table: "Stats",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_UserId_UserEmail",
                table: "Stats",
                columns: new[] { "UserId", "UserEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectId",
                table: "UserProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_UserId_UserEmail",
                table: "UserProjects",
                columns: new[] { "UserId", "UserEmail" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "USERS");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "USERS",
                newName: "USER_NAME");

            migrationBuilder.RenameColumn(
                name: "UserImage",
                table: "USERS",
                newName: "USER_IMAGE");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "USERS",
                newName: "PASSWORD_SALT");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "USERS",
                newName: "PASSWORD_HASH");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "USERS",
                newName: "USER_EMAIL");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "USERS",
                newName: "USER_ID");

            migrationBuilder.AlterColumn<string>(
                name: "USER_EMAIL",
                table: "USERS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_USERS",
                table: "USERS",
                column: "USER_ID");

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
                name: "USER_RECORDS",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SOLUTION_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SEQ_NO = table.Column<int>(type: "int", nullable: false),
                    NOOF_AUTO_GEN_LINES = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    RECORD_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_MAIN_USER_STATS_PROJECT_ID",
                table: "MAIN_USER_STATS",
                column: "PROJECT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTS_USERS_USER_ID",
                table: "PROJECTS_USERS",
                column: "USER_ID");
        }
    }
}
