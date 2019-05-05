using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentifierGenerator.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Identifier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GlobalId = table.Column<Guid>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    FactoryCode = table.Column<string>(maxLength: 30, nullable: true),
                    CategoryCode = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentifierGenerated",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentifierGlobalId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    GeneratedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentifierGenerated", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Identifier_GlobalId",
                table: "Identifier",
                column: "GlobalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Identifier_FactoryCode_CategoryCode",
                table: "Identifier",
                columns: new[] { "FactoryCode", "CategoryCode" });

            migrationBuilder.CreateIndex(
                name: "IX_IdentifierGenerated_IdentifierGlobalId",
                table: "IdentifierGenerated",
                column: "IdentifierGlobalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Identifier");

            migrationBuilder.DropTable(
                name: "IdentifierGenerated");
        }
    }
}
