using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SUT23_Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "InterestPersonLinks",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestPersonLinks", x => new { x.InterestId, x.PersonId, x.LinkId });
                    table.ForeignKey(
                        name: "FK_InterestPersonLinks_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestPersonLinks_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "LinkId");
                    table.ForeignKey(
                        name: "FK_InterestPersonLinks_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "InterestDescription", "InterestName" },
                values: new object[,]
                {
                    { 1, "Programming in C#", "Programmering" },
                    { 2, "Playing golf", "Golf" },
                    { 3, "How they work", "Computers" },
                    { 4, "World of Warcraft", "Gaming" },
                    { 5, "Playing instrument", "Music" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "LinkName" },
                values: new object[,]
                {
                    { 1, "https://sv.wikipedia.org/wiki/Programmering" },
                    { 2, "https://sv.wikipedia.org/wiki/C" },
                    { 3, "https://sv.wikipedia.org/wiki/Golf" },
                    { 4, "https://sv.wikipedia.org/wiki/Tiger_Woods" },
                    { 5, "https://sv.wikipedia.org/wiki/Musik" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "PersonName", "PhoneNr" },
                values: new object[,]
                {
                    { 1, "Peter", "1234567890" },
                    { 2, "Johan", "6758493201" },
                    { 3, "Sara", "0987654321" }
                });

            migrationBuilder.InsertData(
                table: "InterestPersonLinks",
                columns: new[] { "InterestId", "LinkId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 1, 2, 2 },
                    { 1, 3, 3 },
                    { 2, 3, 1 },
                    { 2, 4, 1 },
                    { 3, 3, 3 },
                    { 4, 3, 1 },
                    { 4, 3, 3 },
                    { 5, 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestPersonLinks_LinkId",
                table: "InterestPersonLinks",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPersonLinks_PersonId",
                table: "InterestPersonLinks",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestPersonLinks");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
