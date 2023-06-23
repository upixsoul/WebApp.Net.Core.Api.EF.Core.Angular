using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Net.Core.Api.EF.Core.Angular.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworkDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworkDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworkServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworkServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonasDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonasDetails_Personas_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialNetworks_Personas_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworkSocialNetworkDetails",
                columns: table => new
                {
                    SocialNetworkId = table.Column<int>(type: "int", nullable: false),
                    SocialNetworkDetailId = table.Column<int>(type: "int", nullable: false),
                    InternalAnalisys = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Importance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworkSocialNetworkDetails", x => new { x.SocialNetworkId, x.SocialNetworkDetailId });
                    table.ForeignKey(
                        name: "FK_SocialNetworkSocialNetworkDetails_SocialNetworkDetails_SocialNetworkDetailId",
                        column: x => x.SocialNetworkDetailId,
                        principalTable: "SocialNetworkDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialNetworkSocialNetworkDetails_SocialNetworks_SocialNetworkId",
                        column: x => x.SocialNetworkId,
                        principalTable: "SocialNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworkSocialNetworkService",
                columns: table => new
                {
                    SocialNetworkServicesId = table.Column<int>(type: "int", nullable: false),
                    SocialNetworksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworkSocialNetworkService", x => new { x.SocialNetworkServicesId, x.SocialNetworksId });
                    table.ForeignKey(
                        name: "FK_SocialNetworkSocialNetworkService_SocialNetworks_SocialNetworksId",
                        column: x => x.SocialNetworksId,
                        principalTable: "SocialNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialNetworkSocialNetworkService_SocialNetworkServices_SocialNetworkServicesId",
                        column: x => x.SocialNetworkServicesId,
                        principalTable: "SocialNetworkServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonasDetails_PersonId",
                table: "PersonasDetails",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_PersonId",
                table: "SocialNetworks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworkSocialNetworkDetails_SocialNetworkDetailId",
                table: "SocialNetworkSocialNetworkDetails",
                column: "SocialNetworkDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworkSocialNetworkService_SocialNetworksId",
                table: "SocialNetworkSocialNetworkService",
                column: "SocialNetworksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonasDetails");

            migrationBuilder.DropTable(
                name: "SocialNetworkSocialNetworkDetails");

            migrationBuilder.DropTable(
                name: "SocialNetworkSocialNetworkService");

            migrationBuilder.DropTable(
                name: "SocialNetworkDetails");

            migrationBuilder.DropTable(
                name: "SocialNetworks");

            migrationBuilder.DropTable(
                name: "SocialNetworkServices");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
