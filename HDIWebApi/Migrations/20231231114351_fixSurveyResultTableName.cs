using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class fixSurveyResultTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyResult",
                table: "SurveyResult");

            migrationBuilder.RenameTable(
                name: "SurveyResult",
                newName: "SurveyResults");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResult_SurveyQuestionOptionId1",
                table: "SurveyResults",
                newName: "IX_SurveyResults_SurveyQuestionOptionId1");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResult_SurveyQuestionOptionId",
                table: "SurveyResults",
                newName: "IX_SurveyResults_SurveyQuestionOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResult_SurveyQuestionId1",
                table: "SurveyResults",
                newName: "IX_SurveyResults_SurveyQuestionId1");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResult_SurveyQuestionId",
                table: "SurveyResults",
                newName: "IX_SurveyResults_SurveyQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResult_SurveyBaseId1",
                table: "SurveyResults",
                newName: "IX_SurveyResults_SurveyBaseId1");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResult_SurveyBaseId",
                table: "SurveyResults",
                newName: "IX_SurveyResults_SurveyBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResult_ApplicationUserId1",
                table: "SurveyResults",
                newName: "IX_SurveyResults_ApplicationUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResult_ApplicationUserId",
                table: "SurveyResults",
                newName: "IX_SurveyResults_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyResults",
                table: "SurveyResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_AspNetUsers_ApplicationUserId",
                table: "SurveyResults",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_AspNetUsers_ApplicationUserId1",
                table: "SurveyResults",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_SurveyBases_SurveyBaseId",
                table: "SurveyResults",
                column: "SurveyBaseId",
                principalTable: "SurveyBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_SurveyBases_SurveyBaseId1",
                table: "SurveyResults",
                column: "SurveyBaseId1",
                principalTable: "SurveyBases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_SurveyQuestionOptions_SurveyQuestionOptionId",
                table: "SurveyResults",
                column: "SurveyQuestionOptionId",
                principalTable: "SurveyQuestionOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_SurveyQuestionOptions_SurveyQuestionOptionId1",
                table: "SurveyResults",
                column: "SurveyQuestionOptionId1",
                principalTable: "SurveyQuestionOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_SurveyQuestions_SurveyQuestionId",
                table: "SurveyResults",
                column: "SurveyQuestionId",
                principalTable: "SurveyQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_SurveyQuestions_SurveyQuestionId1",
                table: "SurveyResults",
                column: "SurveyQuestionId1",
                principalTable: "SurveyQuestions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_AspNetUsers_ApplicationUserId",
                table: "SurveyResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_AspNetUsers_ApplicationUserId1",
                table: "SurveyResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_SurveyBases_SurveyBaseId",
                table: "SurveyResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_SurveyBases_SurveyBaseId1",
                table: "SurveyResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_SurveyQuestionOptions_SurveyQuestionOptionId",
                table: "SurveyResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_SurveyQuestionOptions_SurveyQuestionOptionId1",
                table: "SurveyResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_SurveyQuestions_SurveyQuestionId",
                table: "SurveyResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_SurveyQuestions_SurveyQuestionId1",
                table: "SurveyResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyResults",
                table: "SurveyResults");

            migrationBuilder.RenameTable(
                name: "SurveyResults",
                newName: "SurveyResult");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResults_SurveyQuestionOptionId1",
                table: "SurveyResult",
                newName: "IX_SurveyResult_SurveyQuestionOptionId1");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResults_SurveyQuestionOptionId",
                table: "SurveyResult",
                newName: "IX_SurveyResult_SurveyQuestionOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResults_SurveyQuestionId1",
                table: "SurveyResult",
                newName: "IX_SurveyResult_SurveyQuestionId1");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResults_SurveyQuestionId",
                table: "SurveyResult",
                newName: "IX_SurveyResult_SurveyQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResults_SurveyBaseId1",
                table: "SurveyResult",
                newName: "IX_SurveyResult_SurveyBaseId1");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResults_SurveyBaseId",
                table: "SurveyResult",
                newName: "IX_SurveyResult_SurveyBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResults_ApplicationUserId1",
                table: "SurveyResult",
                newName: "IX_SurveyResult_ApplicationUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResults_ApplicationUserId",
                table: "SurveyResult",
                newName: "IX_SurveyResult_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyResult",
                table: "SurveyResult",
                column: "Id");

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
    }
}
