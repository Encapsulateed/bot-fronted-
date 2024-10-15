using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace front_bot.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    chatId = table.Column<long>(type: "bigint", nullable: false),
                    uuid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    JWT = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    command = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    password = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.chatId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
