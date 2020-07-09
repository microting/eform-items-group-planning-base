namespace Microting.ItemsGroupPlanningBase.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DayOfMonthField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RepeatOn",
                table: "ItemListVersions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DayOfMonth",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RepeatOn",
                table: "ItemLists",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DayOfMonth",
                table: "ItemLists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfMonth",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "DayOfMonth",
                table: "ItemLists");

            migrationBuilder.AlterColumn<int>(
                name: "RepeatOn",
                table: "ItemListVersions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RepeatOn",
                table: "ItemLists",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
