using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Persistance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskProgressionLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskProgressionLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lists_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskProgressionLevelsId = table.Column<int>(type: "int", nullable: false),
                    Estimation = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskProgressionLevels_TaskProgressionLevelsId",
                        column: x => x.TaskProgressionLevelsId,
                        principalTable: "TaskProgressionLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Board" });

            migrationBuilder.InsertData(
                table: "TaskProgressionLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ToDo" },
                    { 2, "InProgress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "Id", "BoardId", "Name" },
                values: new object[] { 1, 1, "House Duties" });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "Id", "BoardId", "Name" },
                values: new object[] { 2, 1, "Job" });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "Id", "BoardId", "Name" },
                values: new object[] { 3, 1, "Other" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Duration", "Estimation", "ListId", "Name", "TaskProgressionLevelsId" },
                values: new object[,]
                {
                    { 1, 5, 7, 1, "First task", 2 },
                    { 2, 0, 2, 1, "Second task", 1 },
                    { 3, 0, 3, 1, "Third Task", 1 },
                    { 4, 3, 10, 2, "Fourth task", 2 },
                    { 5, 0, 3, 2, "Fifth task", 1 },
                    { 6, 6, 4, 2, "Sixth Task", 3 },
                    { 7, 15, 15, 3, "Seventh task", 2 },
                    { 8, 5, 2, 3, "Eighth task", 3 },
                    { 9, 5, 6, 3, "Nineth Task", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lists_BoardId",
                table: "Lists",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ListId",
                table: "Tasks",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskProgressionLevelsId",
                table: "Tasks",
                column: "TaskProgressionLevelsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "TaskProgressionLevels");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
