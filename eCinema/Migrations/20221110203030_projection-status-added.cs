using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCinema.Migrations
{
    public partial class projectionstatusadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectionStatus",
                table: "Projections");

            migrationBuilder.AddColumn<string>(
               name: "StateMachine",
               table: "Projections",
               type: "nvarchar(max)",
               nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Projections",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projections");

            migrationBuilder.DropColumn(
               name: "Status",
               table: "Projections");

            migrationBuilder.AddColumn<string>(
              name: "ProjectionStatus",
              table: "Projections",
              type: "nvarchar(max)",
              nullable: true);
        }
    }
}
