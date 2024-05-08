using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectASP.Migrations
{
    /// <inheritdoc />
    public partial class customerIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustId",
                table: "AspNetUsers");
        }
    }
}
