using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoRunner.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlgoDotesResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlgoName = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgoDotesResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlgoTableResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlgoName = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgoTableResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlgoTextResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlgoName = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgoTextResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlgResultTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgResultTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Context = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    isReaded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAlgoLists",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAlgoLists", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAlgos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    AlgoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAlgos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectExecutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExecutedBy = table.Column<string>(maxLength: 250, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ResultPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectExecutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    AdminInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AdminInfos_AdminInfoId",
                        column: x => x.AdminInfoId,
                        principalTable: "AdminInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResultCategories",
                columns: table => new
                {
                    Label = table.Column<string>(maxLength: 250, nullable: false),
                    AlgoDotesResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultCategories", x => x.Label);
                    table.ForeignKey(
                        name: "FK_ResultCategories_AlgoDotesResults_AlgoDotesResultId",
                        column: x => x.AlgoDotesResultId,
                        principalTable: "AlgoDotesResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    ServerPath = table.Column<string>(nullable: true),
                    AdminInfoId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_AdminInfos_AdminInfoId",
                        column: x => x.AdminInfoId,
                        principalTable: "AdminInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    X = table.Column<float>(nullable: false),
                    Y = table.Column<float>(nullable: false),
                    ResultCategoryLabel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_ResultCategories_ResultCategoryLabel",
                        column: x => x.ResultCategoryLabel,
                        principalTable: "ResultCategories",
                        principalColumn: "Label",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    IsFavorite = table.Column<bool>(nullable: false),
                    LastExecutionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Algorithms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    ActivityId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ResultTypeId = table.Column<int>(nullable: false),
                    FileServerPath = table.Column<string>(maxLength: 1000, nullable: true),
                    ProjectAlgoListProjectId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Algorithms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Algorithms_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Algorithms_ProjectAlgoLists_ProjectAlgoListProjectId",
                        column: x => x.ProjectAlgoListProjectId,
                        principalTable: "ProjectAlgoLists",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Algorithms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Algorithms_AlgResultTypes_ResultTypeId",
                        column: x => x.ResultTypeId,
                        principalTable: "AlgResultTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectExecutionId = table.Column<int>(nullable: false),
                    AlgoId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    AlgoName = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ExecutedBy = table.Column<string>(maxLength: 250, nullable: true),
                    FileExePath = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecutionInfos_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlgoParams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Value = table.Column<string>(maxLength: 1000, nullable: true),
                    AlgorithmId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgoParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlgoParams_Algorithms_AlgorithmId",
                        column: x => x.AlgorithmId,
                        principalTable: "Algorithms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlgoExecutionParams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    ExecutionInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgoExecutionParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlgoExecutionParams_ExecutionInfos_ExecutionInfoId",
                        column: x => x.ExecutionInfoId,
                        principalTable: "ExecutionInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AdminInfoId",
                table: "Activities",
                column: "AdminInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AlgoExecutionParams_ExecutionInfoId",
                table: "AlgoExecutionParams",
                column: "ExecutionInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlgoParams_AlgorithmId",
                table: "AlgoParams",
                column: "AlgorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_Algorithms_ActivityId",
                table: "Algorithms",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Algorithms_ProjectAlgoListProjectId",
                table: "Algorithms",
                column: "ProjectAlgoListProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Algorithms_ProjectId",
                table: "Algorithms",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Algorithms_ResultTypeId",
                table: "Algorithms",
                column: "ResultTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionInfos_ProjectId",
                table: "ExecutionInfos",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_ResultCategoryLabel",
                table: "Points",
                column: "ResultCategoryLabel");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ActivityId",
                table: "Projects",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultCategories_AlgoDotesResultId",
                table: "ResultCategories",
                column: "AlgoDotesResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdminInfoId",
                table: "Users",
                column: "AdminInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlgoExecutionParams");

            migrationBuilder.DropTable(
                name: "AlgoParams");

            migrationBuilder.DropTable(
                name: "AlgoTableResults");

            migrationBuilder.DropTable(
                name: "AlgoTextResults");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "ProjectAlgos");

            migrationBuilder.DropTable(
                name: "ProjectExecutions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ExecutionInfos");

            migrationBuilder.DropTable(
                name: "Algorithms");

            migrationBuilder.DropTable(
                name: "ResultCategories");

            migrationBuilder.DropTable(
                name: "ProjectAlgoLists");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AlgResultTypes");

            migrationBuilder.DropTable(
                name: "AlgoDotesResults");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AdminInfos");
        }
    }
}
