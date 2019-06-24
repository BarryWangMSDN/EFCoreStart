using Microsoft.EntityFrameworkCore.Migrations;

namespace SODbLoadV2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
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
                    question_id = table.Column<int>(nullable: false),
                    owneruser_id = table.Column<int>(nullable: true),
                    comment_count = table.Column<int>(nullable: false),
                    is_answered = table.Column<bool>(nullable: false),
                    view_count = table.Column<int>(nullable: false),
                    answer_count = table.Column<int>(nullable: false),
                    score = table.Column<int>(nullable: false),
                    last_activity_date = table.Column<int>(nullable: false),
                    creation_date = table.Column<int>(nullable: false),
                    link = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    last_edit_date = table.Column<int>(nullable: true),
                    accepted_answer_id = table.Column<int>(nullable: true),
                    tags = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    answer_id = table.Column<int>(nullable: false),
                    owneruser_id = table.Column<int>(nullable: true),
                    comment_count = table.Column<int>(nullable: false),
                    is_accepted = table.Column<bool>(nullable: false),
                    score = table.Column<int>(nullable: false),
                    last_activity_date = table.Column<int>(nullable: false),
                    creation_date = table.Column<int>(nullable: false),
                    question_id = table.Column<int>(nullable: false),
                    body = table.Column<string>(nullable: true),
                    last_edit_date = table.Column<int>(nullable: true),
                    Itemquestion_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.answer_id);
                    table.ForeignKey(
                        name: "FK_Answers_Items_Itemquestion_id",
                        column: x => x.Itemquestion_id,
                        principalTable: "Items",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Owners_owneruser_id",
                        column: x => x.owneruser_id,
                        principalTable: "Owners",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    comment_id = table.Column<int>(nullable: false),
                    owneruser_id = table.Column<int>(nullable: true),
                    edited = table.Column<bool>(nullable: false),
                    score = table.Column<int>(nullable: false),
                    creation_date = table.Column<int>(nullable: false),
                    post_id = table.Column<int>(nullable: false),
                    Itemquestion_id = table.Column<int>(nullable: true),
                    answer_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_Comments_Items_Itemquestion_id",
                        column: x => x.Itemquestion_id,
                        principalTable: "Items",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Answers_answer_id",
                        column: x => x.answer_id,
                        principalTable: "Answers",
                        principalColumn: "answer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Owners_owneruser_id",
                        column: x => x.owneruser_id,
                        principalTable: "Owners",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Itemquestion_id",
                table: "Answers",
                column: "Itemquestion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_owneruser_id",
                table: "Answers",
                column: "owneruser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Itemquestion_id",
                table: "Comments",
                column: "Itemquestion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_answer_id",
                table: "Comments",
                column: "answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_owneruser_id",
                table: "Comments",
                column: "owneruser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_owneruser_id",
                table: "Items",
                column: "owneruser_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
