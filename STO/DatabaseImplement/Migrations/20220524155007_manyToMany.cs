using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseImplement.Migrations
{
    public partial class manyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Works_WorkId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_WorkId",
                table: "Repairs");

            migrationBuilder.CreateTable(
                name: "RepairWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairId = table.Column<int>(type: "int", nullable: true),
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    WorkId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairWorks_Repairs_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Repairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairWorks_Works_WorkId1",
                        column: x => x.WorkId1,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairWorks_WorkId",
                table: "RepairWorks",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairWorks_WorkId1",
                table: "RepairWorks",
                column: "WorkId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairWorks");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_WorkId",
                table: "Repairs",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Works_WorkId",
                table: "Repairs",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
