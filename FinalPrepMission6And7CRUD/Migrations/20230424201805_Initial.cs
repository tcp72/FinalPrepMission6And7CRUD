using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalPrepMission6And7CRUD.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MajorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MajorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.MajorId);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<byte>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    CreeperStalker = table.Column<bool>(nullable: false),
                    MajorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Responses_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorName" },
                values: new object[] { 1, "Information Systems" });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorName" },
                values: new object[] { 2, "Ancient Near Eastern Studies" });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorName" },
                values: new object[] { 3, "Accounting" });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorName" },
                values: new object[] { 4, "Actuarial Science" });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorName" },
                values: new object[] { 5, "Undeclared" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "Age", "CreeperStalker", "FirstName", "LastName", "MajorId", "Phone" },
                values: new object[] { 1, (byte)45, true, "Michael", "Scott", 4, "555-555-5555" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "Age", "CreeperStalker", "FirstName", "LastName", "MajorId", "Phone" },
                values: new object[] { 2, (byte)33, false, "John", "Hills", 5, "444-555-5555" });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_MajorId",
                table: "Responses",
                column: "MajorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Majors");
        }
    }
}
