using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HowdyService.Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gifs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    GiphyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anwsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anwsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anwsers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Gifs",
                columns: new[] { "Id", "GiphyId", "Name" },
                values: new object[,]
                {
                    { 1, "wh9Ftb014GmKQ", "Css" },
                    { 2, "10bdAP4IOmoN7G", "JavaScript" },
                    { 3, "ip2GZs8rLxt8k", "JavaVsC++" },
                    { 4, "11CXAq0P8h50GI", "Poker" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "Do you feel groovy?" },
                    { 2, "How's it hanging?" },
                    { 3, "Are you Jivin' yet?" },
                    { 4, "How Well Jacek did on this challange?" }
                });

            migrationBuilder.InsertData(
                table: "Anwsers",
                columns: new[] { "Id", "QuestionId", "Text", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Dream On", 1 },
                    { 2, 1, "You Know", 2 },
                    { 3, 1, "Off the hook", 3 },
                    { 4, 1, "Hell yeah", 4 },
                    { 5, 2, "What it is, what it is", 1 },
                    { 6, 2, "Ace", 2 },
                    { 7, 2, "Primo", 3 },
                    { 8, 2, "Secundo", 4 },
                    { 9, 3, "Buzz Off", 1 },
                    { 10, 3, "Bitch'n", 2 },
                    { 11, 3, "Bangin", 3 },
                    { 12, 3, "Laaame", 4 },
                    { 13, 4, "Ok", 1 },
                    { 14, 4, "Pretty good", 2 },
                    { 15, 4, "Awsome", 3 },
                    { 16, 4, "And we have new student developer!", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anwsers_QuestionId",
                table: "Anwsers",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anwsers");

            migrationBuilder.DropTable(
                name: "Gifs");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
