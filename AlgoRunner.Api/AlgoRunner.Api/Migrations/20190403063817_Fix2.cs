using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoRunner.Api.Migrations
{
    public partial class Fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProjectExecutions_ProjectId",
                table: "ProjectExecutions",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectExecutions_Projects_ProjectId",
                table: "ProjectExecutions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectExecutions_Projects_ProjectId",
                table: "ProjectExecutions");

            migrationBuilder.DropIndex(
                name: "IX_ProjectExecutions_ProjectId",
                table: "ProjectExecutions");
        }
    }
}
