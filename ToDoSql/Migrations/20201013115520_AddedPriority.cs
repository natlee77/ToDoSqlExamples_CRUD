using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoSql_CodeFirst.Migrations
{
    public partial class AddedPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prioriry",
                table: "ToDos",
                type: "int",
                nullable: false,
                defaultValue: 0); // int -automatisk 0
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prioriry",
                table: "ToDos");
        }
    }
}
