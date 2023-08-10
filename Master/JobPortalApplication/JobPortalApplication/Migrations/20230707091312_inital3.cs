using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortalApplication.Migrations
{
    /// <inheritdoc />
    public partial class inital3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Applicati__CompanyId__32E0915F",
                table: "Applications");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CompanyId",
                table: "Applications",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK__Applicati__CompanyId__32E0915F",
                table: "Applications",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Applicati__CompanyId__32E0915F",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CompanyId",
                table: "Applications");

            migrationBuilder.AddForeignKey(
                name: "FK__Applicati__CompanyId__32E0915F",
                table: "Applications",
                column: "UserId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
