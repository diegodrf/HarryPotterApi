using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eyes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hairs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Wood = table.Column<string>(type: "text", nullable: true),
                    Core = table.Column<string>(type: "text", nullable: true),
                    Length = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SpeciesId = table.Column<int>(type: "integer", nullable: true),
                    GenderId = table.Column<int>(type: "integer", nullable: true),
                    HouseId = table.Column<int>(type: "integer", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsWizard = table.Column<bool>(type: "boolean", nullable: false),
                    Ancestry = table.Column<string>(type: "text", nullable: true),
                    EyeId = table.Column<int>(type: "integer", nullable: true),
                    HairId = table.Column<int>(type: "integer", nullable: true),
                    WandId = table.Column<int>(type: "integer", nullable: true),
                    Patronus = table.Column<string>(type: "text", nullable: true),
                    IsHogwartsStudent = table.Column<bool>(type: "boolean", nullable: false),
                    IsHogwartsStaff = table.Column<bool>(type: "boolean", nullable: false),
                    Actor = table.Column<string>(type: "text", nullable: false),
                    IsAlive = table.Column<bool>(type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Eyes_EyeId",
                        column: x => x.EyeId,
                        principalTable: "Eyes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Hairs_HairId",
                        column: x => x.HairId,
                        principalTable: "Hairs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Wands_WandId",
                        column: x => x.WandId,
                        principalTable: "Wands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EyeId",
                table: "Characters",
                column: "EyeId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GenderId",
                table: "Characters",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HairId",
                table: "Characters",
                column: "HairId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HouseId",
                table: "Characters",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SpeciesId",
                table: "Characters",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WandId",
                table: "Characters",
                column: "WandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Eyes");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Hairs");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Wands");
        }
    }
}
