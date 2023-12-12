using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSATask.DAL.Migrations
{
    public partial class AddedLogicForDateTimeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 1, new DateTime(2020, 8, 19, 9, 55, 26, 581, DateTimeKind.Local).AddTicks(6236), new DateTime(2025, 6, 26, 8, 18, 51, 541, DateTimeKind.Local).AddTicks(5745), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Generic Fresh Ball", 6 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name" },
                values: new object[] { 1, new DateTime(2021, 8, 17, 0, 25, 26, 562, DateTimeKind.Local).AddTicks(5687), new DateTime(2025, 7, 1, 3, 57, 8, 684, DateTimeKind.Local).AddTicks(485), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Fantastic Concrete Tuna" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name" },
                values: new object[] { 3, new DateTime(2021, 4, 3, 3, 57, 38, 538, DateTimeKind.Local).AddTicks(2341), new DateTime(2024, 6, 19, 17, 36, 55, 676, DateTimeKind.Local).AddTicks(1882), "The Football Is Good For Training And Recreational Purposes", "Rustic Wooden Mouse" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name" },
                values: new object[] { 5, new DateTime(2020, 12, 27, 22, 29, 51, 765, DateTimeKind.Local).AddTicks(8165), new DateTime(2024, 8, 21, 20, 24, 12, 473, DateTimeKind.Local).AddTicks(3675), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Sleek Concrete Table" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 6, new DateTime(2022, 6, 18, 21, 32, 55, 742, DateTimeKind.Local).AddTicks(6986), new DateTime(2024, 11, 12, 5, 29, 13, 964, DateTimeKind.Local).AddTicks(7712), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Handcrafted Soft Bike", 3 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 9, new DateTime(2021, 9, 2, 14, 12, 20, 268, DateTimeKind.Local).AddTicks(2015), new DateTime(2024, 3, 15, 23, 18, 36, 996, DateTimeKind.Local).AddTicks(7869), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Awesome Cotton Cheese", 7 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 4, new DateTime(2022, 10, 26, 18, 7, 5, 371, DateTimeKind.Local).AddTicks(8529), new DateTime(2024, 9, 16, 11, 39, 57, 549, DateTimeKind.Local).AddTicks(6266), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Sleek Metal Table", 2 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 3, new DateTime(2022, 5, 16, 14, 58, 17, 993, DateTimeKind.Local).AddTicks(8426), new DateTime(2023, 10, 25, 13, 27, 29, 4, DateTimeKind.Local).AddTicks(9259), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Tasty Metal Keyboard", 6 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 4, new DateTime(2022, 4, 6, 8, 25, 38, 175, DateTimeKind.Local).AddTicks(5186), new DateTime(2024, 9, 1, 15, 14, 22, 461, DateTimeKind.Local).AddTicks(7958), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Refined Granite Chicken", 7 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 2, new DateTime(2021, 6, 10, 4, 40, 35, 599, DateTimeKind.Local).AddTicks(8958), new DateTime(2024, 5, 18, 0, 9, 41, 672, DateTimeKind.Local).AddTicks(4525), "The Football Is Good For Training And Recreational Purposes", "Practical Metal Mouse", 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "FinishedAt", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[] { new DateTime(2023, 5, 30, 6, 46, 34, 105, DateTimeKind.Local).AddTicks(6757), "Aperiam possimus consequatur animi omnis molestiae accusamus fuga dignissimos.", null, "odio", 7, 5, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId" },
                values: new object[] { new DateTime(2022, 7, 27, 6, 40, 55, 788, DateTimeKind.Local).AddTicks(7670), "Dolores consequatur aperiam architecto deleniti corrupti aut provident voluptas.", "vel", 1, 10 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[] { new DateTime(2022, 4, 15, 7, 37, 36, 412, DateTimeKind.Local).AddTicks(6215), "Ut rerum est dolorem provident odio fugiat aut eum voluptatem.", "voluptatem", 3, 8, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "FinishedAt", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[] { new DateTime(2023, 8, 3, 7, 40, 24, 899, DateTimeKind.Local).AddTicks(9461), "Ex facere veniam.", null, "omnis", 4, 2, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "FinishedAt", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[] { new DateTime(2023, 6, 25, 18, 26, 58, 979, DateTimeKind.Local).AddTicks(6302), "Fugit non sit est omnis sit temporibus.", new DateTime(2023, 3, 6, 17, 3, 22, 677, DateTimeKind.Local).AddTicks(9043), "est", 1, 6, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "FinishedAt", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[] { new DateTime(2022, 2, 20, 21, 43, 57, 207, DateTimeKind.Local).AddTicks(4441), "Exercitationem molestiae occaecati.", null, "consequatur", 1, 4, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId" },
                values: new object[] { new DateTime(2023, 2, 14, 20, 22, 1, 985, DateTimeKind.Local).AddTicks(3472), "Repellat aperiam est.", "at", 1, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId" },
                values: new object[] { new DateTime(2021, 2, 14, 2, 16, 6, 334, DateTimeKind.Local).AddTicks(6081), "Molestiae nobis similique adipisci.", "cumque", 2, 8 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId" },
                values: new object[] { new DateTime(2023, 2, 2, 6, 0, 31, 910, DateTimeKind.Local).AddTicks(763), "Vero ut illum quod eum impedit magnam sunt.", "sapiente", 9, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId" },
                values: new object[] { new DateTime(2022, 9, 15, 17, 50, 8, 904, DateTimeKind.Local).AddTicks(2102), "Quo earum dolor rem est sint sit delectus.", "harum", 6, 7 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 20, 15, 788, DateTimeKind.Local).AddTicks(3343), "Hintz LLC" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 4, 28, 18, 40, 48, 227, DateTimeKind.Local).AddTicks(759), "Haag, Collins and D'Amore" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 4, 1, 10, 12, 5, 660, DateTimeKind.Local).AddTicks(2792), "VonRueden Inc" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2022, 4, 5, 12, 8, 3, 841, DateTimeKind.Local).AddTicks(999), "Johnson - Schamberger" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 1, 16, 19, 32, 2, 18, DateTimeKind.Local).AddTicks(1221), "Powlowski, Wintheiser and Toy" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2022, 7, 12, 5, 13, 53, 375, DateTimeKind.Local).AddTicks(9931), "Kulas and Sons" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 3, 23, 2, 59, 37, 611, DateTimeKind.Local).AddTicks(4024), "Hayes - Grant" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2020, 12, 15, 11, 39, 53, 704, DateTimeKind.Local).AddTicks(7605), "Keebler - Hills" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 9, 9, 4, 33, 20, 533, DateTimeKind.Local).AddTicks(8463), "DuBuque, Ryan and Schumm" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 10, 5, 2, 51, 45, 462, DateTimeKind.Local).AddTicks(4173), "Frami, Kshlerin and Cremin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1987, 1, 26, 11, 49, 56, 913, DateTimeKind.Unspecified).AddTicks(3656), "Sophia37@hotmail.com", "Sophia", "Glover", new DateTime(2022, 4, 6, 14, 27, 54, 459, DateTimeKind.Local).AddTicks(9870), 9 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1998, 4, 11, 10, 37, 38, 753, DateTimeKind.Unspecified).AddTicks(7280), "Sheldon.Cassin41@yahoo.com", "Sheldon", "Cassin", new DateTime(2021, 2, 7, 5, 58, 55, 588, DateTimeKind.Local).AddTicks(432), 7 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1971, 7, 14, 11, 37, 31, 29, DateTimeKind.Unspecified).AddTicks(6260), "Patsy.Hahn@yahoo.com", "Patsy", "Hahn", new DateTime(2020, 11, 6, 6, 43, 24, 519, DateTimeKind.Local).AddTicks(8415), 8 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1925, 10, 10, 16, 32, 23, 56, DateTimeKind.Unspecified).AddTicks(6945), "Heidi_Roob@yahoo.com", "Heidi", "Roob", new DateTime(2021, 11, 10, 9, 57, 17, 676, DateTimeKind.Local).AddTicks(3585), 5 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1956, 7, 19, 10, 45, 8, 421, DateTimeKind.Unspecified).AddTicks(2066), "Cora98@gmail.com", "Cora", "Cormier", new DateTime(2022, 8, 19, 15, 20, 2, 429, DateTimeKind.Local).AddTicks(9427), 8 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1952, 7, 23, 15, 38, 17, 301, DateTimeKind.Unspecified).AddTicks(3182), "Glen90@yahoo.com", "Glen", "Lang", new DateTime(2021, 12, 2, 23, 46, 15, 530, DateTimeKind.Local).AddTicks(6895), 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1953, 11, 2, 5, 38, 31, 385, DateTimeKind.Unspecified).AddTicks(7234), "Charlene.Hane@hotmail.com", "Charlene", "Hane", new DateTime(2022, 4, 15, 16, 37, 42, 615, DateTimeKind.Local).AddTicks(2835), 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1929, 5, 7, 3, 30, 12, 496, DateTimeKind.Unspecified).AddTicks(2365), "Jennie_Stoltenberg24@yahoo.com", "Jennie", "Stoltenberg", new DateTime(2020, 12, 11, 15, 55, 46, 868, DateTimeKind.Local).AddTicks(7366), 6 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1943, 10, 24, 11, 13, 50, 826, DateTimeKind.Unspecified).AddTicks(9222), "Kathryn_Cormier@yahoo.com", "Kathryn", "Cormier", new DateTime(2021, 1, 1, 12, 43, 33, 542, DateTimeKind.Local).AddTicks(988), 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1960, 5, 24, 12, 49, 5, 311, DateTimeKind.Unspecified).AddTicks(1208), "Kenny.Pagac@gmail.com", "Kenny", "Pagac", new DateTime(2023, 6, 14, 20, 39, 21, 33, DateTimeKind.Local).AddTicks(8440), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 7, new DateTime(2022, 8, 21, 18, 27, 25, 703, DateTimeKind.Local).AddTicks(3271), new DateTime(2024, 11, 22, 17, 40, 47, 738, DateTimeKind.Local).AddTicks(3867), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Rustic Wooden Chips", 10 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name" },
                values: new object[] { 6, new DateTime(2023, 6, 16, 15, 32, 12, 377, DateTimeKind.Local).AddTicks(1794), new DateTime(2025, 6, 6, 3, 43, 9, 668, DateTimeKind.Local).AddTicks(4254), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Sleek Steel Hat" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name" },
                values: new object[] { 2, new DateTime(2021, 8, 28, 0, 52, 12, 877, DateTimeKind.Local).AddTicks(4832), new DateTime(2024, 5, 1, 10, 6, 51, 582, DateTimeKind.Local).AddTicks(4611), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Fantastic Frozen Chips" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name" },
                values: new object[] { 7, new DateTime(2020, 12, 13, 17, 5, 6, 301, DateTimeKind.Local).AddTicks(5663), new DateTime(2024, 8, 14, 17, 5, 5, 413, DateTimeKind.Local).AddTicks(4038), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Gorgeous Rubber Table" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 2, new DateTime(2022, 11, 27, 4, 56, 47, 722, DateTimeKind.Local).AddTicks(8057), new DateTime(2024, 11, 1, 23, 34, 3, 920, DateTimeKind.Local).AddTicks(4845), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Rustic Plastic Sausages", 8 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 6, new DateTime(2023, 2, 19, 3, 40, 15, 134, DateTimeKind.Local).AddTicks(6493), new DateTime(2025, 1, 22, 15, 0, 14, 236, DateTimeKind.Local).AddTicks(1860), "The Football Is Good For Training And Recreational Purposes", "Incredible Metal Pants", 10 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 6, new DateTime(2022, 10, 10, 9, 39, 15, 538, DateTimeKind.Local).AddTicks(4392), new DateTime(2024, 1, 19, 14, 25, 40, 445, DateTimeKind.Local).AddTicks(5221), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Handcrafted Granite Tuna", 10 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 4, new DateTime(2021, 9, 1, 20, 47, 42, 479, DateTimeKind.Local).AddTicks(5366), new DateTime(2024, 10, 24, 9, 30, 6, 752, DateTimeKind.Local).AddTicks(1983), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Handmade Frozen Chair", 10 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 5, new DateTime(2021, 3, 21, 5, 54, 5, 260, DateTimeKind.Local).AddTicks(8681), new DateTime(2025, 4, 17, 19, 30, 46, 346, DateTimeKind.Local).AddTicks(4547), "The Football Is Good For Training And Recreational Purposes", "Gorgeous Metal Computer", 3 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 9, new DateTime(2023, 1, 16, 21, 57, 39, 481, DateTimeKind.Local).AddTicks(405), new DateTime(2024, 8, 25, 4, 59, 39, 698, DateTimeKind.Local).AddTicks(3171), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Intelligent Cotton Keyboard", 7 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "FinishedAt", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[] { new DateTime(2021, 9, 7, 6, 39, 54, 444, DateTimeKind.Local).AddTicks(3528), "Quia provident quas.", new DateTime(2022, 9, 16, 18, 59, 20, 796, DateTimeKind.Local).AddTicks(4660), "eaque", 3, 8, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId" },
                values: new object[] { new DateTime(2021, 7, 2, 19, 20, 39, 505, DateTimeKind.Local).AddTicks(823), "Aut velit velit.", "exercitationem", 3, 8 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[] { new DateTime(2020, 9, 5, 7, 8, 49, 530, DateTimeKind.Local).AddTicks(9673), "Minus voluptas eum cupiditate quia qui est.", "molestiae", 5, 9, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "FinishedAt", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[] { new DateTime(2021, 9, 30, 2, 57, 59, 274, DateTimeKind.Local).AddTicks(2086), "Est quia consequatur minima harum ut ipsam est architecto unde.", new DateTime(2023, 1, 10, 6, 58, 4, 482, DateTimeKind.Local).AddTicks(4428), "ea", 8, 10, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "FinishedAt", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[] { new DateTime(2021, 2, 6, 13, 27, 19, 405, DateTimeKind.Local).AddTicks(2782), "Libero illo perspiciatis voluptatum dolore praesentium nihil ipsa.", null, "fugit", 10, 8, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "FinishedAt", "Name", "PerformerId", "ProjectId", "State" },
                values: new object[] { new DateTime(2023, 1, 15, 18, 12, 12, 725, DateTimeKind.Local).AddTicks(8891), "Ducimus incidunt saepe ut dolor.", new DateTime(2023, 6, 1, 20, 6, 29, 83, DateTimeKind.Local).AddTicks(3726), "delectus", 5, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId" },
                values: new object[] { new DateTime(2022, 7, 27, 20, 56, 24, 298, DateTimeKind.Local).AddTicks(2155), "Sit aut enim ipsam est.", "qui", 4, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId" },
                values: new object[] { new DateTime(2022, 12, 6, 19, 15, 51, 649, DateTimeKind.Local).AddTicks(1308), "Eaque voluptas quia deleniti rerum dolorum accusamus dignissimos vel.", "cupiditate", 10, 4 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId" },
                values: new object[] { new DateTime(2022, 4, 3, 20, 44, 0, 209, DateTimeKind.Local).AddTicks(5399), "Et iste dolore.", "est", 5, 8 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Name", "PerformerId", "ProjectId" },
                values: new object[] { new DateTime(2021, 6, 13, 7, 48, 52, 894, DateTimeKind.Local).AddTicks(2949), "Laboriosam est eos magni.", "aut", 10, 9 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 1, 19, 10, 26, 6, 379, DateTimeKind.Local).AddTicks(1989), "Bartell Group" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2022, 1, 21, 7, 28, 59, 925, DateTimeKind.Local).AddTicks(4939), "Shanahan and Sons" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2022, 12, 13, 20, 33, 35, 686, DateTimeKind.Local).AddTicks(6049), "Gorczany Inc" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2022, 7, 20, 5, 29, 9, 415, DateTimeKind.Local).AddTicks(5391), "Lang, Batz and Sporer" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 6, 8, 9, 25, 46, 756, DateTimeKind.Local).AddTicks(5123), "Jaskolski Group" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2020, 9, 21, 0, 54, 57, 230, DateTimeKind.Local).AddTicks(64), "Heidenreich LLC" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 59, 49, 322, DateTimeKind.Local).AddTicks(1774), "Farrell Inc" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 12, 23, 1, 4, 42, 153, DateTimeKind.Local).AddTicks(3176), "Kiehn, Moore and Skiles" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 3, 27, 9, 19, 57, 804, DateTimeKind.Local).AddTicks(7613), "Johnston - Grady" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2022, 10, 10, 7, 13, 51, 477, DateTimeKind.Local).AddTicks(4128), "Mante, Homenick and Schowalter" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1966, 10, 19, 2, 55, 49, 916, DateTimeKind.Unspecified).AddTicks(672), "Lorraine96@hotmail.com", "Lorraine", "Jacobson", new DateTime(2023, 1, 30, 11, 44, 13, 976, DateTimeKind.Local).AddTicks(8935), 6 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1924, 4, 30, 19, 15, 55, 975, DateTimeKind.Unspecified).AddTicks(8688), "Katrina65@hotmail.com", "Katrina", "Hickle", new DateTime(2022, 11, 13, 21, 29, 3, 590, DateTimeKind.Local).AddTicks(7730), 8 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(2005, 7, 14, 16, 56, 39, 935, DateTimeKind.Unspecified).AddTicks(1036), "Joy.Koss@gmail.com", "Joy", "Koss", new DateTime(2022, 4, 14, 20, 25, 30, 893, DateTimeKind.Local).AddTicks(4963), 5 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(2003, 11, 22, 4, 26, 12, 953, DateTimeKind.Unspecified).AddTicks(8856), "Lori.Ebert@gmail.com", "Lori", "Ebert", new DateTime(2023, 2, 10, 19, 1, 18, 487, DateTimeKind.Local).AddTicks(219), 7 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1971, 1, 2, 0, 43, 22, 13, DateTimeKind.Unspecified).AddTicks(944), "Eunice.Volkman@yahoo.com", "Eunice", "Volkman", new DateTime(2021, 4, 11, 12, 36, 43, 359, DateTimeKind.Local).AddTicks(5452), 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1996, 3, 27, 6, 10, 46, 67, DateTimeKind.Unspecified).AddTicks(4652), "Alfonso.Stark13@gmail.com", "Alfonso", "Stark", new DateTime(2020, 8, 10, 3, 49, 48, 633, DateTimeKind.Local).AddTicks(8816), 8 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1943, 12, 10, 12, 41, 46, 52, DateTimeKind.Unspecified).AddTicks(9635), "Curtis.Nader@yahoo.com", "Curtis", "Nader", new DateTime(2020, 11, 1, 22, 2, 6, 515, DateTimeKind.Local).AddTicks(3759), 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(2006, 9, 1, 19, 58, 59, 227, DateTimeKind.Unspecified).AddTicks(4), "Cedric83@yahoo.com", "Cedric", "Bayer", new DateTime(2020, 8, 22, 14, 47, 43, 178, DateTimeKind.Local).AddTicks(994), 7 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1994, 11, 9, 17, 10, 58, 259, DateTimeKind.Unspecified).AddTicks(5512), "Alfred47@yahoo.com", "Alfred", "Ankunding", new DateTime(2021, 5, 28, 11, 30, 57, 202, DateTimeKind.Local).AddTicks(7432), 7 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[] { new DateTime(1930, 4, 14, 18, 16, 41, 746, DateTimeKind.Unspecified).AddTicks(6458), "Angelo_Wilkinson@yahoo.com", "Angelo", "Wilkinson", new DateTime(2023, 6, 22, 18, 26, 16, 894, DateTimeKind.Local).AddTicks(7337), 10 });
        }
    }
}
