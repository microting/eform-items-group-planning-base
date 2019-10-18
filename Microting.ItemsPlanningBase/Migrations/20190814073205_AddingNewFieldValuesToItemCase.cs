using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddingNewFieldValuesToItemCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DescriptionEnabled",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DoneAtEnabled",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DoneByUserNameEnabled",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LabelEnabled",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled1",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled10",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled2",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled3",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled4",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled5",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled6",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled7",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled8",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled9",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId1",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId10",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId2",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId3",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId4",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId5",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId6",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId7",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId8",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId9",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UploadedDataEnabled",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DescriptionEnabled",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DoneAtEnabled",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DoneByUserNameEnabled",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LabelEnabled",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled1",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled10",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled2",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled3",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled4",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled5",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled6",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled7",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled8",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SdkFieldEnabled9",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId1",
                table: "ItemLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId10",
                table: "ItemLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId2",
                table: "ItemLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId3",
                table: "ItemLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId4",
                table: "ItemLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId5",
                table: "ItemLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId6",
                table: "ItemLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId7",
                table: "ItemLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId8",
                table: "ItemLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SdkFieldId9",
                table: "ItemLists",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UploadedDataEnabled",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue1",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue10",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue2",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue3",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue4",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue5",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue6",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue7",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue8",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue9",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue1",
                table: "ItemCases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue10",
                table: "ItemCases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue2",
                table: "ItemCases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue3",
                table: "ItemCases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue4",
                table: "ItemCases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue5",
                table: "ItemCases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue6",
                table: "ItemCases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue7",
                table: "ItemCases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue8",
                table: "ItemCases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkFieldValue9",
                table: "ItemCases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEnabled",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "DoneAtEnabled",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "DoneByUserNameEnabled",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "LabelEnabled",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled1",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled10",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled2",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled3",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled4",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled5",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled6",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled7",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled8",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled9",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId1",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId10",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId2",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId3",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId4",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId5",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId6",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId7",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId8",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldId9",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "UploadedDataEnabled",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "DescriptionEnabled",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "DoneAtEnabled",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "DoneByUserNameEnabled",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "LabelEnabled",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled1",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled10",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled2",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled3",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled4",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled5",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled6",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled7",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled8",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldEnabled9",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldId1",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldId10",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldId2",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldId3",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldId4",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldId5",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldId6",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldId7",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldId8",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldId9",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "UploadedDataEnabled",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue1",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue10",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue2",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue3",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue4",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue5",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue6",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue7",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue8",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue9",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue1",
                table: "ItemCases");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue10",
                table: "ItemCases");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue2",
                table: "ItemCases");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue3",
                table: "ItemCases");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue4",
                table: "ItemCases");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue5",
                table: "ItemCases");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue6",
                table: "ItemCases");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue7",
                table: "ItemCases");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue8",
                table: "ItemCases");

            migrationBuilder.DropColumn(
                name: "SdkFieldValue9",
                table: "ItemCases");
        }
    }
}
