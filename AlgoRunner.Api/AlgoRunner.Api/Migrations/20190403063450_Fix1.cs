using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoRunner.Api.Migrations
{
    public partial class Fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionInfos_Projects_ProjectId1",
                table: "ExecutionInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectAlgos_Projects_ProjectId1",
                table: "ProjectAlgos");

            migrationBuilder.RenameColumn(
                name: "ProjectId1",
                table: "ProjectAlgos",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectAlgos_ProjectId1",
                table: "ProjectAlgos",
                newName: "IX_ProjectAlgos_ProjectId");

            migrationBuilder.RenameColumn(
                name: "ProjectId1",
                table: "ExecutionInfos",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutionInfos_ProjectId1",
                table: "ExecutionInfos",
                newName: "IX_ExecutionInfos_ProjectId");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "ProjectExecutions",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionInfos_Projects_ProjectId",
                table: "ExecutionInfos",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectAlgos_Projects_ProjectId",
                table: "ProjectAlgos",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionInfos_Projects_ProjectId",
                table: "ExecutionInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectAlgos_Projects_ProjectId",
                table: "ProjectAlgos");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectExecutions");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectAlgos",
                newName: "ProjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectAlgos_ProjectId",
                table: "ProjectAlgos",
                newName: "IX_ProjectAlgos_ProjectId1");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ExecutionInfos",
                newName: "ProjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutionInfos_ProjectId",
                table: "ExecutionInfos",
                newName: "IX_ExecutionInfos_ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionInfos_Projects_ProjectId1",
                table: "ExecutionInfos",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectAlgos_Projects_ProjectId1",
                table: "ProjectAlgos",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
