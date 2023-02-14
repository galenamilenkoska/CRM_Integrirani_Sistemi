using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentCRM.Repository.Migrations
{
    public partial class sql2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sender = table.Column<string>(nullable: true),
                    recipients = table.Column<string>(nullable: true),
                    subject = table.Column<string>(nullable: true),
                    body = table.Column<string>(nullable: true),
                    studentId = table.Column<int>(nullable: true),
                    professorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_professorId",
                        column: x => x.professorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_professorId",
                table: "Message",
                column: "professorId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_studentId",
                table: "Message",
                column: "studentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");
        }
    }
}
