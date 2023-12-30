using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class changeSurveyNameToSurveyBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestions_Surveys_ExpandSurveyId",
                table: "SurveyQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestions_Surveys_SurveyId",
                table: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "SurveyQuestions",
                newName: "SurveyBaseId");

            migrationBuilder.RenameColumn(
                name: "ExpandSurveyId",
                table: "SurveyQuestions",
                newName: "ExpandSurveyBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyQuestions_SurveyId",
                table: "SurveyQuestions",
                newName: "IX_SurveyQuestions_SurveyBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyQuestions_ExpandSurveyId",
                table: "SurveyQuestions",
                newName: "IX_SurveyQuestions_ExpandSurveyBaseId");

            migrationBuilder.CreateTable(
                name: "SurveyBases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    Updater = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyBases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyBases_SurveyBases_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SurveyBases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyBases_ParentId",
                table: "SurveyBases",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_SurveyBases_ExpandSurveyBaseId",
                table: "SurveyQuestions",
                column: "ExpandSurveyBaseId",
                principalTable: "SurveyBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_SurveyBases_SurveyBaseId",
                table: "SurveyQuestions",
                column: "SurveyBaseId",
                principalTable: "SurveyBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestions_SurveyBases_ExpandSurveyBaseId",
                table: "SurveyQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestions_SurveyBases_SurveyBaseId",
                table: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "SurveyBases");

            migrationBuilder.RenameColumn(
                name: "SurveyBaseId",
                table: "SurveyQuestions",
                newName: "SurveyId");

            migrationBuilder.RenameColumn(
                name: "ExpandSurveyBaseId",
                table: "SurveyQuestions",
                newName: "ExpandSurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyQuestions_SurveyBaseId",
                table: "SurveyQuestions",
                newName: "IX_SurveyQuestions_SurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyQuestions_ExpandSurveyBaseId",
                table: "SurveyQuestions",
                newName: "IX_SurveyQuestions_ExpandSurveyId");

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Updater = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Surveys_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_ParentId",
                table: "Surveys",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_Surveys_ExpandSurveyId",
                table: "SurveyQuestions",
                column: "ExpandSurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_Surveys_SurveyId",
                table: "SurveyQuestions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
