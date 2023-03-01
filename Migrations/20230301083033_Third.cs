using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace votingApp2.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Option_Poll_poll_id",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_Poll_Votters_owner_id",
                table: "Poll");

            migrationBuilder.DropIndex(
                name: "IX_Poll_owner_id",
                table: "Poll");

            migrationBuilder.DropIndex(
                name: "IX_Option_poll_id",
                table: "Option");

            migrationBuilder.AddColumn<int>(
                name: "poll_id1",
                table: "Option",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Option_poll_id1",
                table: "Option",
                column: "poll_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Poll_poll_id1",
                table: "Option",
                column: "poll_id1",
                principalTable: "Poll",
                principalColumn: "poll_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Option_Poll_poll_id1",
                table: "Option");

            migrationBuilder.DropIndex(
                name: "IX_Option_poll_id1",
                table: "Option");

            migrationBuilder.DropColumn(
                name: "poll_id1",
                table: "Option");

            migrationBuilder.CreateIndex(
                name: "IX_Poll_owner_id",
                table: "Poll",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_Option_poll_id",
                table: "Option",
                column: "poll_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Poll_poll_id",
                table: "Option",
                column: "poll_id",
                principalTable: "Poll",
                principalColumn: "poll_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poll_Votters_owner_id",
                table: "Poll",
                column: "owner_id",
                principalTable: "Votters",
                principalColumn: "user_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
