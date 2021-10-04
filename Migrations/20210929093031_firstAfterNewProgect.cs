using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlannerAPI2.Migrations
{
    public partial class firstAfterNewProgect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Person",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Age = table.Column<int>(type: "int", nullable: false),
            //        JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Person", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TodoItems",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IsCompleted = table.Column<bool>(type: "bit", nullable: false),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CloseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TodoItems", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Person");

            //migrationBuilder.DropTable(
            //    name: "TodoItems");
        }
    }
}
