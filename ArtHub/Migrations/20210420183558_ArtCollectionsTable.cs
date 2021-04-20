using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtHub.Migrations
{
    public partial class ArtCollectionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtCollections",
                columns: table => new
                {
                    ArtId = table.Column<int>(type: "int", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtCollections", x => new { x.ArtId, x.CollectionId });
                    table.ForeignKey(
                        name: "FK_ArtCollections_Art_ArtId",
                        column: x => x.ArtId,
                        principalTable: "Art",
                        principalColumn: "ArtId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArtCollections_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtCollections_CollectionId",
                table: "ArtCollections",
                column: "CollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtCollections");
        }
    }
}
