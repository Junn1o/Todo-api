using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseMigrationv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Category_CategoryID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Tasks",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "TaskID",
                table: "Tasks",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_CategoryID",
                table: "Tasks",
                newName: "IX_Tasks_CategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Tasks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Category_CategoryId",
                table: "Tasks",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Category_CategoryId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Tasks",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Tasks",
                newName: "TaskID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_CategoryId",
                table: "Tasks",
                newName: "IX_Tasks_CategoryID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Category_CategoryID",
                table: "Tasks",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryId");
        }
    }
}
