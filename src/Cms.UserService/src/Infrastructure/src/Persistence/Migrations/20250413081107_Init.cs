using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cms.UserService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(name: "cms-user-service");

            migrationBuilder.CreateTable(
                name: "user",
                schema: "cms-user-service",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user___id", x => x.id);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_user___image_id",
                schema: "cms-user-service",
                table: "user",
                column: "image_id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "user", schema: "cms-user-service");
        }
    }
}
