using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoSql_CodeFirst.Migrations
{
    public partial class RemovedPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prioriry",
                table: "ToDos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prioriry",
                table: "ToDos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
