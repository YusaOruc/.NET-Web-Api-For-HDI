using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ExpandSurveyBaseIdMoveToOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestions_SurveyBases_ExpandSurveyBaseId",
                table: "SurveyQuestions");

            migrationBuilder.DropIndex(
                name: "IX_SurveyQuestions_ExpandSurveyBaseId",
                table: "SurveyQuestions");

            migrationBuilder.DropColumn(
                name: "ExpandSurveyBaseId",
                table: "SurveyQuestions");

            migrationBuilder.AddColumn<int>(
                name: "ExpandSurveyBaseId",
                table: "SurveyQuestionOptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionOptions_ExpandSurveyBaseId",
                table: "SurveyQuestionOptions",
                column: "ExpandSurveyBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionOptions_SurveyBases_ExpandSurveyBaseId",
                table: "SurveyQuestionOptions",
                column: "ExpandSurveyBaseId",
                principalTable: "SurveyBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestionOptions_SurveyBases_ExpandSurveyBaseId",
                table: "SurveyQuestionOptions");

            migrationBuilder.DropIndex(
                name: "IX_SurveyQuestionOptions_ExpandSurveyBaseId",
                table: "SurveyQuestionOptions");

            migrationBuilder.DropColumn(
                name: "ExpandSurveyBaseId",
                table: "SurveyQuestionOptions");

            migrationBuilder.AddColumn<int>(
                name: "ExpandSurveyBaseId",
                table: "SurveyQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_ExpandSurveyBaseId",
                table: "SurveyQuestions",
                column: "ExpandSurveyBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_SurveyBases_ExpandSurveyBaseId",
                table: "SurveyQuestions",
                column: "ExpandSurveyBaseId",
                principalTable: "SurveyBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
