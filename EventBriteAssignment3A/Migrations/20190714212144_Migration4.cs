using Microsoft.EntityFrameworkCore.Migrations;

namespace EventBriteAssignment3A.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Catalog",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Catalog",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
