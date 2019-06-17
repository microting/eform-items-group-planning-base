using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class SchedulingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepeatOn",
                table: "ItemListVersions",
                newName: "MaxExecutedCount");

            migrationBuilder.RenameColumn(
                name: "RepeatOn",
                table: "ItemLists",
                newName: "MaxExecutedCount");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExecutedCount",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastExecutedTime",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "ItemLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExecutedCount",
                table: "ItemLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastExecutedTime",
                table: "ItemLists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "ExecutedCount",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "LastExecutedTime",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "ExecutedCount",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "LastExecutedTime",
                table: "ItemLists");

            migrationBuilder.RenameColumn(
                name: "MaxExecutedCount",
                table: "ItemListVersions",
                newName: "RepeatOn");

            migrationBuilder.RenameColumn(
                name: "MaxExecutedCount",
                table: "ItemLists",
                newName: "RepeatOn");
        }
    }
}
