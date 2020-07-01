using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 150, nullable: false),
                    LastName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 2500, nullable: true),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("681b93e7-9c12-4abb-83bd-8f686717f31a"), "George", "Martin" },
                    { new Guid("03634c2d-5279-4dc1-8a92-b32d33408778"), "Stephen", "Fry" },
                    { new Guid("aa675ba5-f906-45e1-9d2d-b1293ff82f3e"), "James", "Elroy" },
                    { new Guid("be59b3c4-d918-46df-a7cd-17db5b68a0b2"), "Douglas", "Adams" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[] { new Guid("e49ba68c-8c1d-479e-bb6c-de9fab807bde"), new Guid("681b93e7-9c12-4abb-83bd-8f686717f31a"), "The book that seems impossible to write", "The Winds of Winter" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[] { new Guid("49174169-e8e6-4955-aaca-23547750bcc3"), new Guid("03634c2d-5279-4dc1-8a92-b32d33408778"), "A Game of Thrones is the first novel...", "A Game of Thrones" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[] { new Guid("2d3e6f72-1ae4-4159-865a-77e5abc259f3"), new Guid("aa675ba5-f906-45e1-9d2d-b1293ff82f3e"), "The Greeks myths are amongst the best stories ever told...", "Mythos" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
