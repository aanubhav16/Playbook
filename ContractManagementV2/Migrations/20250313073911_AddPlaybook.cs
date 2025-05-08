using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractManagementV2.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaybook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playbooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaybookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaybookDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playbooks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Playbooks");
        }
    }
}
