namespace Microting.ItemsGroupPlanningBase.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddItemListFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepeatType",
                table: "ItemVersions",
                newName: "LocationCode");

            migrationBuilder.RenameColumn(
                name: "RepeatType",
                table: "Items",
                newName: "LocationCode");

            migrationBuilder.RenameColumn(
                name: "RelatedeFormName",
                table: "ItemListVersions",
                newName: "RelatedEFormName");

            migrationBuilder.RenameColumn(
                name: "RelatedeFormId",
                table: "ItemListVersions",
                newName: "RelatedEFormId");

            migrationBuilder.RenameColumn(
                name: "RepeatedType",
                table: "ItemListVersions",
                newName: "RepeatEvery");

            migrationBuilder.RenameColumn(
                name: "RelatedeFormName",
                table: "ItemLists",
                newName: "RelatedEFormName");

            migrationBuilder.RenameColumn(
                name: "RelatedeFormId",
                table: "ItemLists",
                newName: "RelatedEFormId");

            migrationBuilder.RenameColumn(
                name: "RepeatedType",
                table: "ItemLists",
                newName: "RepeatEvery");

            migrationBuilder.AddColumn<string>(
                name: "ItemNumber",
                table: "ItemVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "ItemVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ItemNumber",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RepeatOn",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RepeatType",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RepeatUntil",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepeatOn",
                table: "ItemLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RepeatType",
                table: "ItemLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RepeatUntil",
                table: "ItemLists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemNumber",
                table: "ItemVersions");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "ItemVersions");

            migrationBuilder.DropColumn(
                name: "ItemNumber",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RepeatOn",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "RepeatType",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "RepeatUntil",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "RepeatOn",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "RepeatType",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "RepeatUntil",
                table: "ItemLists");

            migrationBuilder.RenameColumn(
                name: "LocationCode",
                table: "ItemVersions",
                newName: "RepeatType");

            migrationBuilder.RenameColumn(
                name: "LocationCode",
                table: "Items",
                newName: "RepeatType");

            migrationBuilder.RenameColumn(
                name: "RelatedEFormName",
                table: "ItemListVersions",
                newName: "RelatedeFormName");

            migrationBuilder.RenameColumn(
                name: "RelatedEFormId",
                table: "ItemListVersions",
                newName: "RelatedeFormId");

            migrationBuilder.RenameColumn(
                name: "RepeatEvery",
                table: "ItemListVersions",
                newName: "RepeatedType");

            migrationBuilder.RenameColumn(
                name: "RelatedEFormName",
                table: "ItemLists",
                newName: "RelatedeFormName");

            migrationBuilder.RenameColumn(
                name: "RelatedEFormId",
                table: "ItemLists",
                newName: "RelatedeFormId");

            migrationBuilder.RenameColumn(
                name: "RepeatEvery",
                table: "ItemLists",
                newName: "RepeatedType");
        }
    }
}
