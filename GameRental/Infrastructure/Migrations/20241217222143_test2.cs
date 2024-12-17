using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesLeased_Users_UserId",
                table: "GamesLeased");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GamesLeased",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "GamesLeased",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameOfferId",
                table: "GamesLeased",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamesLeased_RenterId",
                table: "GamesLeased",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesLeased_GamesOffered_UserId",
                table: "GamesLeased",
                column: "UserId",
                principalTable: "GamesOffered",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GamesLeased_Users_RenterId",
                table: "GamesLeased",
                column: "RenterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesLeased_GamesOffered_UserId",
                table: "GamesLeased");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesLeased_Users_RenterId",
                table: "GamesLeased");

            migrationBuilder.DropIndex(
                name: "IX_GamesLeased_RenterId",
                table: "GamesLeased");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "GamesLeased");

            migrationBuilder.DropColumn(
                name: "GameOfferId",
                table: "GamesLeased");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GamesLeased",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GamesLeased_Users_UserId",
                table: "GamesLeased",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
