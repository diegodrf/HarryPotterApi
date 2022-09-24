using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    public partial class RemoveHairandEyeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Eyes_EyeId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Hairs_HairId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Eyes");

            migrationBuilder.DropTable(
                name: "Hairs");

            migrationBuilder.DropIndex(
                name: "IX_Characters_EyeId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_HairId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "EyeId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HairId",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "Eye",
                table: "Characters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hair",
                table: "Characters",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eye",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Hair",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "EyeId",
                table: "Characters",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HairId",
                table: "Characters",
                type: "integer",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EyeId",
                table: "Characters",
                column: "EyeId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HairId",
                table: "Characters",
                column: "HairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Eyes_EyeId",
                table: "Characters",
                column: "EyeId",
                principalTable: "Eyes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Hairs_HairId",
                table: "Characters",
                column: "HairId",
                principalTable: "Hairs",
                principalColumn: "Id");
        }
    }
}
