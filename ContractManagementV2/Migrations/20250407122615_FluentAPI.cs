using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractManagementV2.Migrations
{
    /// <inheritdoc />
    public partial class FluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlaybookName",
                table: "Playbooks",
                newName: "NamePlaybook");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NamePlaybook",
                table: "Playbooks",
                newName: "PlaybookName");
        }
    }
}
