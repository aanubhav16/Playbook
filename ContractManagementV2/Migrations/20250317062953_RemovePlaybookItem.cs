using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractManagementV2.Migrations
{
    /// <inheritdoc />
    public partial class RemovePlaybookItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaybookItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaybookItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaybookId = table.Column<int>(type: "int", nullable: false),
                    ClauseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClauseValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaybookItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaybookItem_Playbooks_PlaybookId",
                        column: x => x.PlaybookId,
                        principalTable: "Playbooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaybookItem_PlaybookId",
                table: "PlaybookItem",
                column: "PlaybookId");
        }
    }
}
