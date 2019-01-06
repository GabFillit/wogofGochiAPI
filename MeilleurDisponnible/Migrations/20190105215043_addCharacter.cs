using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeilleurDisponnible.Migrations
{
    public partial class addCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameEntity_UserEntity_UserId",
                table: "GameEntity");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GameEntity",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "CharacterEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CurrentStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterEntity_GameEntity_GameId",
                        column: x => x.GameId,
                        principalTable: "GameEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEntity_GameId",
                table: "CharacterEntity",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntity_UserEntity_UserId",
                table: "GameEntity",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameEntity_UserEntity_UserId",
                table: "GameEntity");

            migrationBuilder.DropTable(
                name: "CharacterEntity");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GameEntity",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntity_UserEntity_UserId",
                table: "GameEntity",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
