using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractManagementV2.Migrations
{
    /// <inheritdoc />
    public partial class AddingPlaybookItemAgainWithPlural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaybookItems",
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
                    table.PrimaryKey("PK_PlaybookItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaybookItems_Playbooks_PlaybookId",
                        column: x => x.PlaybookId,
                        principalTable: "Playbooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaybookItems_PlaybookId",
                table: "PlaybookItems",
                column: "PlaybookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaybookItems");
        }
    }
}
