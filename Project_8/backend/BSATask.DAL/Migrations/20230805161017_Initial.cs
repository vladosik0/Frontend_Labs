using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSATask.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    PerformerId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Users_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 19, 10, 26, 6, 379, DateTimeKind.Local).AddTicks(1989), "Bartell Group" },
                    { 2, new DateTime(2022, 1, 21, 7, 28, 59, 925, DateTimeKind.Local).AddTicks(4939), "Shanahan and Sons" },
                    { 3, new DateTime(2022, 12, 13, 20, 33, 35, 686, DateTimeKind.Local).AddTicks(6049), "Gorczany Inc" },
                    { 4, new DateTime(2022, 7, 20, 5, 29, 9, 415, DateTimeKind.Local).AddTicks(5391), "Lang, Batz and Sporer" },
                    { 5, new DateTime(2023, 6, 8, 9, 25, 46, 756, DateTimeKind.Local).AddTicks(5123), "Jaskolski Group" },
                    { 6, new DateTime(2020, 9, 21, 0, 54, 57, 230, DateTimeKind.Local).AddTicks(64), "Heidenreich LLC" },
                    { 7, new DateTime(2022, 6, 3, 3, 59, 49, 322, DateTimeKind.Local).AddTicks(1774), "Farrell Inc" },
                    { 8, new DateTime(2021, 12, 23, 1, 4, 42, 153, DateTimeKind.Local).AddTicks(3176), "Kiehn, Moore and Skiles" },
                    { 9, new DateTime(2021, 3, 27, 9, 19, 57, 804, DateTimeKind.Local).AddTicks(7613), "Johnston - Grady" },
                    { 10, new DateTime(2022, 10, 10, 7, 13, 51, 477, DateTimeKind.Local).AddTicks(4128), "Mante, Homenick and Schowalter" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(1966, 10, 19, 2, 55, 49, 916, DateTimeKind.Unspecified).AddTicks(672), "Lorraine96@hotmail.com", "Lorraine", "Jacobson", new DateTime(2023, 1, 30, 11, 44, 13, 976, DateTimeKind.Local).AddTicks(8935), 6 },
                    { 2, new DateTime(1924, 4, 30, 19, 15, 55, 975, DateTimeKind.Unspecified).AddTicks(8688), "Katrina65@hotmail.com", "Katrina", "Hickle", new DateTime(2022, 11, 13, 21, 29, 3, 590, DateTimeKind.Local).AddTicks(7730), 8 },
                    { 3, new DateTime(2005, 7, 14, 16, 56, 39, 935, DateTimeKind.Unspecified).AddTicks(1036), "Joy.Koss@gmail.com", "Joy", "Koss", new DateTime(2022, 4, 14, 20, 25, 30, 893, DateTimeKind.Local).AddTicks(4963), 5 },
                    { 4, new DateTime(2003, 11, 22, 4, 26, 12, 953, DateTimeKind.Unspecified).AddTicks(8856), "Lori.Ebert@gmail.com", "Lori", "Ebert", new DateTime(2023, 2, 10, 19, 1, 18, 487, DateTimeKind.Local).AddTicks(219), 7 },
                    { 5, new DateTime(1971, 1, 2, 0, 43, 22, 13, DateTimeKind.Unspecified).AddTicks(944), "Eunice.Volkman@yahoo.com", "Eunice", "Volkman", new DateTime(2021, 4, 11, 12, 36, 43, 359, DateTimeKind.Local).AddTicks(5452), 1 },
                    { 6, new DateTime(1996, 3, 27, 6, 10, 46, 67, DateTimeKind.Unspecified).AddTicks(4652), "Alfonso.Stark13@gmail.com", "Alfonso", "Stark", new DateTime(2020, 8, 10, 3, 49, 48, 633, DateTimeKind.Local).AddTicks(8816), 8 },
                    { 7, new DateTime(1943, 12, 10, 12, 41, 46, 52, DateTimeKind.Unspecified).AddTicks(9635), "Curtis.Nader@yahoo.com", "Curtis", "Nader", new DateTime(2020, 11, 1, 22, 2, 6, 515, DateTimeKind.Local).AddTicks(3759), 2 },
                    { 8, new DateTime(2006, 9, 1, 19, 58, 59, 227, DateTimeKind.Unspecified).AddTicks(4), "Cedric83@yahoo.com", "Cedric", "Bayer", new DateTime(2020, 8, 22, 14, 47, 43, 178, DateTimeKind.Local).AddTicks(994), 7 },
                    { 9, new DateTime(1994, 11, 9, 17, 10, 58, 259, DateTimeKind.Unspecified).AddTicks(5512), "Alfred47@yahoo.com", "Alfred", "Ankunding", new DateTime(2021, 5, 28, 11, 30, 57, 202, DateTimeKind.Local).AddTicks(7432), 7 },
                    { 10, new DateTime(1930, 4, 14, 18, 16, 41, 746, DateTimeKind.Unspecified).AddTicks(6458), "Angelo_Wilkinson@yahoo.com", "Angelo", "Wilkinson", new DateTime(2023, 6, 22, 18, 26, 16, 894, DateTimeKind.Local).AddTicks(7337), 10 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[,]
                {
                    { 1, 7, new DateTime(2022, 8, 21, 18, 27, 25, 703, DateTimeKind.Local).AddTicks(3271), new DateTime(2024, 11, 22, 17, 40, 47, 738, DateTimeKind.Local).AddTicks(3867), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Rustic Wooden Chips", 10 },
                    { 2, 6, new DateTime(2023, 6, 16, 15, 32, 12, 377, DateTimeKind.Local).AddTicks(1794), new DateTime(2025, 6, 6, 3, 43, 9, 668, DateTimeKind.Local).AddTicks(4254), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Sleek Steel Hat", 8 },
                    { 3, 2, new DateTime(2021, 8, 28, 0, 52, 12, 877, DateTimeKind.Local).AddTicks(4832), new DateTime(2024, 5, 1, 10, 6, 51, 582, DateTimeKind.Local).AddTicks(4611), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Fantastic Frozen Chips", 2 },
                    { 4, 7, new DateTime(2020, 12, 13, 17, 5, 6, 301, DateTimeKind.Local).AddTicks(5663), new DateTime(2024, 8, 14, 17, 5, 5, 413, DateTimeKind.Local).AddTicks(4038), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Gorgeous Rubber Table", 2 },
                    { 5, 2, new DateTime(2022, 11, 27, 4, 56, 47, 722, DateTimeKind.Local).AddTicks(8057), new DateTime(2024, 11, 1, 23, 34, 3, 920, DateTimeKind.Local).AddTicks(4845), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Rustic Plastic Sausages", 8 },
                    { 6, 6, new DateTime(2023, 2, 19, 3, 40, 15, 134, DateTimeKind.Local).AddTicks(6493), new DateTime(2025, 1, 22, 15, 0, 14, 236, DateTimeKind.Local).AddTicks(1860), "The Football Is Good For Training And Recreational Purposes", "Incredible Metal Pants", 10 },
                    { 7, 6, new DateTime(2022, 10, 10, 9, 39, 15, 538, DateTimeKind.Local).AddTicks(4392), new DateTime(2024, 1, 19, 14, 25, 40, 445, DateTimeKind.Local).AddTicks(5221), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Handcrafted Granite Tuna", 10 },
                    { 8, 4, new DateTime(2021, 9, 1, 20, 47, 42, 479, DateTimeKind.Local).AddTicks(5366), new DateTime(2024, 10, 24, 9, 30, 6, 752, DateTimeKind.Local).AddTicks(1983), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Handmade Frozen Chair", 10 },
                    { 9, 5, new DateTime(2021, 3, 21, 5, 54, 5, 260, DateTimeKind.Local).AddTicks(8681), new DateTime(2025, 4, 17, 19, 30, 46, 346, DateTimeKind.Local).AddTicks(4547), "The Football Is Good For Training And Recreational Purposes", "Gorgeous Metal Computer", 3 },
                    { 10, 9, new DateTime(2023, 1, 16, 21, 57, 39, 481, DateTimeKind.Local).AddTicks(405), new DateTime(2024, 8, 25, 4, 59, 39, 698, DateTimeKind.Local).AddTicks(3171), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Intelligent Cotton Keyboard", 7 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "FinishedAt", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 7, 6, 39, 54, 444, DateTimeKind.Local).AddTicks(3528), "Quia provident quas.", new DateTime(2022, 9, 16, 18, 59, 20, 796, DateTimeKind.Local).AddTicks(4660), "eaque", 3, 8, 2 },
                    { 2, new DateTime(2021, 7, 2, 19, 20, 39, 505, DateTimeKind.Local).AddTicks(823), "Aut velit velit.", null, "exercitationem", 3, 8, 3 },
                    { 3, new DateTime(2020, 9, 5, 7, 8, 49, 530, DateTimeKind.Local).AddTicks(9673), "Minus voluptas eum cupiditate quia qui est.", null, "molestiae", 5, 9, 3 },
                    { 4, new DateTime(2021, 9, 30, 2, 57, 59, 274, DateTimeKind.Local).AddTicks(2086), "Est quia consequatur minima harum ut ipsam est architecto unde.", new DateTime(2023, 1, 10, 6, 58, 4, 482, DateTimeKind.Local).AddTicks(4428), "ea", 8, 10, 2 },
                    { 5, new DateTime(2021, 2, 6, 13, 27, 19, 405, DateTimeKind.Local).AddTicks(2782), "Libero illo perspiciatis voluptatum dolore praesentium nihil ipsa.", null, "fugit", 10, 8, 3 },
                    { 6, new DateTime(2023, 1, 15, 18, 12, 12, 725, DateTimeKind.Local).AddTicks(8891), "Ducimus incidunt saepe ut dolor.", new DateTime(2023, 6, 1, 20, 6, 29, 83, DateTimeKind.Local).AddTicks(3726), "delectus", 5, 1, 2 },
                    { 7, new DateTime(2022, 7, 27, 20, 56, 24, 298, DateTimeKind.Local).AddTicks(2155), "Sit aut enim ipsam est.", null, "qui", 4, 1, 3 },
                    { 8, new DateTime(2022, 12, 6, 19, 15, 51, 649, DateTimeKind.Local).AddTicks(1308), "Eaque voluptas quia deleniti rerum dolorum accusamus dignissimos vel.", null, "cupiditate", 10, 4, 0 },
                    { 9, new DateTime(2022, 4, 3, 20, 44, 0, 209, DateTimeKind.Local).AddTicks(5399), "Et iste dolore.", null, "est", 5, 8, 3 },
                    { 10, new DateTime(2021, 6, 13, 7, 48, 52, 894, DateTimeKind.Local).AddTicks(2949), "Laboriosam est eos magni.", null, "aut", 10, 9, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AuthorId",
                table: "Projects",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PerformerId",
                table: "Tasks",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
