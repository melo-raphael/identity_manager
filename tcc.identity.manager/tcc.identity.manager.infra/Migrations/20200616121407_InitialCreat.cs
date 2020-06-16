using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tcc.identity.manager.infra.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValue: new Guid("c0c285de-86cd-4838-80d6-77900690d726")),
                    _email = table.Column<string>(nullable: false),
                    _name = table.Column<string>(nullable: false),
                    _password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authorization",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValue: new Guid("bd954012-6855-4c41-ab77-bdf7ad052e55")),
                    UserIdentityId = table.Column<Guid>(nullable: true),
                    _profile = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authorization_User_UserIdentityId",
                        column: x => x.UserIdentityId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authorization_UserIdentityId",
                table: "Authorization",
                column: "UserIdentityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authorization");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
