using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CorrectQuestionIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorrectQuestionIndex",
                table: "SurveyQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectQuestionIndex",
                table: "SurveyQuestions");
        }
    }
}
