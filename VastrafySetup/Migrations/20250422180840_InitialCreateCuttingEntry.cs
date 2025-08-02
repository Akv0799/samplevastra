using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VastrafySetup.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateCuttingEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuttingEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StyleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuttingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Styles_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeQuantity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CuttingEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeQuantity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeQuantity_CuttingEntries_CuttingEntryId",
                        column: x => x.CuttingEntryId,
                        principalTable: "CuttingEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuttingEntryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuttingEntryId = table.Column<int>(type: "int", nullable: false),
                    CuttingEntryId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StyleId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingEntryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuttingEntryDetails_CuttingEntries_CuttingEntryId1",
                        column: x => x.CuttingEntryId1,
                        principalTable: "CuttingEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuttingEntryDetails_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuttingEntryDetails_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuttingEntryDetails_CuttingEntryId1",
                table: "CuttingEntryDetails",
                column: "CuttingEntryId1");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingEntryDetails_SizeId",
                table: "CuttingEntryDetails",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingEntryDetails_StyleId",
                table: "CuttingEntryDetails",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeQuantity_CuttingEntryId",
                table: "SizeQuantity",
                column: "CuttingEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_Name",
                table: "Sizes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Styles_BrandId",
                table: "Styles",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuttingEntryDetails");

            migrationBuilder.DropTable(
                name: "SizeQuantity");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "CuttingEntries");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
