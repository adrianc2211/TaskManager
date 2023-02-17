using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerApp.Migrations
{
    public partial class ManyToManyConnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StatusCodes_StatusCodeCode",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusCodes",
                table: "StatusCodes");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "StatusCodeCode",
                table: "Tasks",
                newName: "StatusCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_StatusCodeCode",
                table: "Tasks",
                newName: "IX_Tasks_StatusCodeId");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "StatusCodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "StatusCodes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusCodes",
                table: "StatusCodes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TaskUser",
                columns: table => new
                {
                    TasksId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUser", x => new { x.TasksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TaskUser_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskUser_UsersId",
                table: "TaskUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StatusCodes_StatusCodeId",
                table: "Tasks",
                column: "StatusCodeId",
                principalTable: "StatusCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StatusCodes_StatusCodeId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusCodes",
                table: "StatusCodes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StatusCodes");

            migrationBuilder.RenameColumn(
                name: "StatusCodeId",
                table: "Tasks",
                newName: "StatusCodeCode");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_StatusCodeId",
                table: "Tasks",
                newName: "IX_Tasks_StatusCodeCode");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "StatusCodes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusCodes",
                table: "StatusCodes",
                column: "Code");

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCodeCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_UserTasks_StatusCodes_StatusCodeCode",
                        column: x => x.StatusCodeCode,
                        principalTable: "StatusCodes",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_StatusCodeCode",
                table: "UserTasks",
                column: "StatusCodeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StatusCodes_StatusCodeCode",
                table: "Tasks",
                column: "StatusCodeCode",
                principalTable: "StatusCodes",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
