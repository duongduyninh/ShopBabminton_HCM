using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopBabmintonHCM.Migrations
{
    /// <inheritdoc />
    public partial class updateTableCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameCategory",
                table: "Categorys",
                newName: "CategoryName");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categorys",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categorys",
                newName: "NameCategory");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categorys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
