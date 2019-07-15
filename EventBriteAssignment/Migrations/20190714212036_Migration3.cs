using Microsoft.EntityFrameworkCore.Migrations;

namespace EventBriteAssignment3A.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Catalog",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Catalog",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
