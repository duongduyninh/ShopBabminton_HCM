using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopBabmintonHCM.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseTableCtegory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categorys",
                newName: "NameCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameCategory",
                table: "Categorys",
                newName: "Name");
        }
    }
}
