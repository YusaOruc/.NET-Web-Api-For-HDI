using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateSurveyResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "SurveyResult");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SurveyResult",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "SurveyResult",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurveyBaseId",
                table: "SurveyResult",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurveyBaseId1",
                table: "SurveyResult",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurveyQuestionId",
                table: "SurveyResult",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurveyQuestionId1",
                table: "SurveyResult",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurveyQuestionOptionId",
                table: "SurveyResult",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurveyQuestionOptionId1",
                table: "SurveyResult",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResult_ApplicationUserId",
                table: "SurveyResult",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResult_ApplicationUserId1",
                table: "SurveyResult",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResult_SurveyBaseId",
                table: "SurveyResult",
                column: "SurveyBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResult_SurveyBaseId1",
                table: "SurveyResult",
                column: "SurveyBaseId1");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResult_SurveyQuestionId",
                table: "SurveyResult",
                column: "SurveyQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResult_SurveyQuestionId1",
                table: "SurveyResult",
                column: "SurveyQuestionId1");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResult_SurveyQuestionOptionId",
                table: "SurveyResult",
                column: "SurveyQuestionOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResult_SurveyQuestionOptionId1",
                table: "SurveyResult",
                column: "SurveyQuestionOptionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResult_AspNetUsers_ApplicationUserId",
                table: "SurveyResult",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResult_AspNetUsers_ApplicationUserId1",
                table: "SurveyResult",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResult_SurveyBases_SurveyBaseId",
                table: "SurveyResult",
                column: "SurveyBaseId",
                principalTable: "SurveyBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResult_SurveyBases_SurveyBaseId1",
                table: "SurveyResult",
                column: "SurveyBaseId1",
                principalTable: "SurveyBases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResult_SurveyQuestionOptions_SurveyQuestionOptionId",
                table: "SurveyResult",
                column: "SurveyQuestionOptionId",
                principalTable: "SurveyQuestionOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResult_SurveyQuestionOptions_SurveyQuestionOptionId1",
                table: "SurveyResult",
                column: "SurveyQuestionOptionId1",
                principalTable: "SurveyQuestionOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResult_SurveyQuestions_SurveyQuestionId",
                table: "SurveyResult",
                column: "SurveyQuestionId",
                principalTable: "SurveyQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResult_SurveyQuestions_SurveyQuestionId1",
                table: "SurveyResult",
                column: "SurveyQuestionId1",
                principalTable: "SurveyQuestions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResult_AspNetUsers_ApplicationUserId",
                table: "SurveyResult");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResult_AspNetUsers_ApplicationUserId1",
                table: "SurveyResult");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResult_SurveyBases_SurveyBaseId",
                table: "SurveyResult");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResult_SurveyBases_SurveyBaseId1",
                table: "SurveyResult");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResult_SurveyQuestionOptions_SurveyQuestionOptionId",
                table: "SurveyResult");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResult_SurveyQuestionOptions_SurveyQuestionOptionId1",
                table: "SurveyResult");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResult_SurveyQuestions_SurveyQuestionId",
                table: "SurveyResult");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResult_SurveyQuestions_SurveyQuestionId1",
                table: "SurveyResult");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResult_ApplicationUserId",
                table: "SurveyResult");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResult_ApplicationUserId1",
                table: "SurveyResult");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResult_SurveyBaseId",
                table: "SurveyResult");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResult_SurveyBaseId1",
                table: "SurveyResult");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResult_SurveyQuestionId",
                table: "SurveyResult");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResult_SurveyQuestionId1",
                table: "SurveyResult");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResult_SurveyQuestionOptionId",
                table: "SurveyResult");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResult_SurveyQuestionOptionId1",
                table: "SurveyResult");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SurveyResult");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "SurveyResult");

            migrationBuilder.DropColumn(
                name: "SurveyBaseId",
                table: "SurveyResult");

            migrationBuilder.DropColumn(
                name: "SurveyBaseId1",
                table: "SurveyResult");

            migrationBuilder.DropColumn(
                name: "SurveyQuestionId",
                table: "SurveyResult");

            migrationBuilder.DropColumn(
                name: "SurveyQuestionId1",
                table: "SurveyResult");

            migrationBuilder.DropColumn(
                name: "SurveyQuestionOptionId",
                table: "SurveyResult");

            migrationBuilder.DropColumn(
                name: "SurveyQuestionOptionId1",
                table: "SurveyResult");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "SurveyResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
