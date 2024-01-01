using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class fixCorrectQuestionOptionIndexName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrectQuestionIndex",
                table: "SurveyQuestions",
                newName: "CorrectQuestionOptionIndex");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrectQuestionOptionIndex",
                table: "SurveyQuestions",
                newName: "CorrectQuestionIndex");
        }
    }
}
