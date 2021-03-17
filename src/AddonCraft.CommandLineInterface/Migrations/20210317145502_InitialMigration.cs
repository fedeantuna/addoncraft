using System;
using AddonCraft.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddonCraft.CommandLineInterface.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metadata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExternalId = table.Column<int>(type: "INTEGER", nullable: false),
                    PackageName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    GameFlavor = table.Column<GameFlavor.GameFlavorEnum>(type: "INTEGER", nullable: false),
                    ReleaseType = table.Column<ReleaseType.ReleaseTypeEnum>(type: "INTEGER", nullable: false),
                    MetadataId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addons_Metadata_MetadataId",
                        column: x => x.MetadataId,
                        principalTable: "Metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    AddonId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Addons_AddonId",
                        column: x => x.AddonId,
                        principalTable: "Addons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addons_Id_GameFlavor_ReleaseType",
                table: "Addons",
                columns: new[] { "Id", "GameFlavor", "ReleaseType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addons_MetadataId",
                table: "Addons",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_Addons_Name_GameFlavor_ReleaseType",
                table: "Addons",
                columns: new[] { "Name", "GameFlavor", "ReleaseType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_PackageName",
                table: "Metadata",
                column: "PackageName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_AddonId",
                table: "Modules",
                column: "AddonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Addons");

            migrationBuilder.DropTable(
                name: "Metadata");
        }
    }
}
