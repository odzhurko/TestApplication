using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApp.Library.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryCode = table.Column<string>(nullable: false),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Fabrics",
                columns: table => new
                {
                    FabricId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FabricCode = table.Column<string>(nullable: false),
                    FabricName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrics", x => x.FabricId);
                });

            migrationBuilder.CreateTable(
                name: "Identifiers",
                columns: table => new
                {
                    IdentifierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentifierNumber = table.Column<int>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    FabricId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifiers", x => x.IdentifierId);
                    table.ForeignKey(
                        name: "FK_Identifiers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Identifiers_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "FabricId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryCode",
                table: "Categories",
                column: "CategoryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fabrics_FabricCode",
                table: "Fabrics",
                column: "FabricCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_CategoryId",
                table: "Identifiers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_FabricId_CategoryId_IdentifierId",
                table: "Identifiers",
                columns: new[] { "FabricId", "CategoryId", "IdentifierId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Identifiers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Fabrics");
        }
    }
}
