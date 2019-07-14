using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventBriteAssignment3A.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_category_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_location_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: true),
                    EventStartTime = table.Column<DateTime>(nullable: false),
                    EventEndTime = table.Column<DateTime>(nullable: false),
                    CatalogCategoryId = table.Column<int>(nullable: false),
                    CatalogLocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogCategories_CatalogCategoryId",
                        column: x => x.CatalogCategoryId,
                        principalTable: "CatalogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogLocation_CatalogLocationId",
                        column: x => x.CatalogLocationId,
                        principalTable: "CatalogLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogCategoryId",
                table: "Catalog",
                column: "CatalogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogLocationId",
                table: "Catalog",
                column: "CatalogLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogCategories");

            migrationBuilder.DropTable(
                name: "CatalogLocation");

            migrationBuilder.DropSequence(
                name: "catalog_category_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_location_hilo");
        }
    }
}
