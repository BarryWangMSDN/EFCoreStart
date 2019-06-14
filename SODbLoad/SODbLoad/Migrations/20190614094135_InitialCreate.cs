using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SODbLoad.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    reputation = table.Column<int>(nullable: false),
                    user_type = table.Column<string>(nullable: true),
                    accept_rate = table.Column<int>(nullable: false),
                    profile_image = table.Column<string>(nullable: true),
                    display_name = table.Column<string>(nullable: true),
                    link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    question_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    owneruser_id = table.Column<int>(nullable: true),
                    is_answered = table.Column<bool>(nullable: false),
                    view_count = table.Column<int>(nullable: false),
                    answer_count = table.Column<int>(nullable: false),
                    score = table.Column<int>(nullable: false),
                    last_activity_date = table.Column<int>(nullable: false),
                    creation_date = table.Column<int>(nullable: false),
                    link = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    last_edit_date = table.Column<int>(nullable: true),
                    closed_date = table.Column<int>(nullable: true),
                    closed_reason = table.Column<string>(nullable: true),
                    TagCollection = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.question_id);
                    table.ForeignKey(
                        name: "FK_Items_Owners_owneruser_id",
                        column: x => x.owneruser_id,
                        principalTable: "Owners",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_owneruser_id",
                table: "Items",
                column: "owneruser_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
