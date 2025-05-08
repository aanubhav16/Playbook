using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractManagementV2.Migrations
{
    /// <inheritdoc />
    public partial class AddUserBasedPlaybook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Playbooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Playbooks");
        }
    }
}
