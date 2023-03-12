using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PMS");

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                schema: "PMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "PMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ProductState = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Price = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    ProductGroupId = table.Column<long>(type: "bigint", nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 3, 12, 14, 22, 27, 176, DateTimeKind.Local).AddTicks(4241))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalSchema: "PMS",
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComment",
                schema: "PMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CommentText = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComment_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "PMS",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDescription",
                schema: "PMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductDescriptionText = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDescription_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "PMS",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Id",
                schema: "PMS",
                table: "Product",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                schema: "PMS",
                table: "Product",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductGroupId",
                schema: "PMS",
                table: "Product",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_ProductId",
                schema: "PMS",
                table: "ProductComment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDescription_Id",
                schema: "PMS",
                table: "ProductDescription",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDescription_ProductId",
                schema: "PMS",
                table: "ProductDescription",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_Id",
                schema: "PMS",
                table: "ProductGroup",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductComment",
                schema: "PMS");

            migrationBuilder.DropTable(
                name: "ProductDescription",
                schema: "PMS");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "PMS");

            migrationBuilder.DropTable(
                name: "ProductGroup",
                schema: "PMS");
        }
    }
}
