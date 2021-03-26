﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace RoBHo_GameEngine.Migrations
{
    public partial class CharacterCharacterLvl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterClass = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterLvls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lvl = table.Column<int>(type: "int", nullable: false),
                    CurrentXp = table.Column<int>(type: "int", nullable: false),
                    LvlType = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    CharacterId1 = table.Column<int>(type: "int", nullable: true),
                    CharacterId2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterLvls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterLvls_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterLvls_Character_CharacterId1",
                        column: x => x.CharacterId1,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterLvls_Character_CharacterId2",
                        column: x => x.CharacterId2,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterLvls_CharacterId",
                table: "CharacterLvls",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterLvls_CharacterId1",
                table: "CharacterLvls",
                column: "CharacterId1",
                unique: true,
                filter: "[CharacterId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterLvls_CharacterId2",
                table: "CharacterLvls",
                column: "CharacterId2",
                unique: true,
                filter: "[CharacterId2] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterLvls");

            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
