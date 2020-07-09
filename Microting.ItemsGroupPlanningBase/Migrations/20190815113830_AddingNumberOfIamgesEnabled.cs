namespace Microting.ItemsGroupPlanningBase.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddingNumberOfIamgesEnabled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NumberOfImagesEnabled",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NumberOfImagesEnabled",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfImagesEnabled",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "NumberOfImagesEnabled",
                table: "ItemLists");
        }
    }
}
