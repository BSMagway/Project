using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectServer.Migrations
{
    /// <inheritdoc />
    public partial class TestDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ContractNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoistureSoilTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MoistureSoilTestId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialName = table.Column<string>(type: "TEXT", nullable: false),
                    CostumerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateTest = table.Column<string>(type: "TEXT", nullable: false),
                    DocumentTest = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoistureSoilTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoistureSoilTests_Costumers_CostumerId",
                        column: x => x.CostumerId,
                        principalTable: "Costumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dimendions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MoistureSoilTestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DimensionName = table.Column<string>(type: "TEXT", nullable: false),
                    DimensionValue = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimendions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dimendions_MoistureSoilTests_MoistureSoilTestId",
                        column: x => x.MoistureSoilTestId,
                        principalTable: "MoistureSoilTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dimendions_MoistureSoilTestId",
                table: "Dimendions",
                column: "MoistureSoilTestId");

            migrationBuilder.CreateIndex(
                name: "IX_MoistureSoilTests_CostumerId",
                table: "MoistureSoilTests",
                column: "CostumerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dimendions");

            migrationBuilder.DropTable(
                name: "MoistureSoilTests");

            migrationBuilder.DropTable(
                name: "Costumers");
        }
    }
}
