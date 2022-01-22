using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Upload_File_Pjt.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cSVUploads",
                columns: table => new
                {
                    csvUploadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tranIdentificator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    currencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tranDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cSVUploads", x => x.csvUploadId);
                });

            migrationBuilder.CreateTable(
                name: "xmlUploads",
                columns: table => new
                {
                    xmlUpladId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tranId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    currencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tranDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xmlUploads", x => x.xmlUpladId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cSVUploads");

            migrationBuilder.DropTable(
                name: "xmlUploads");
        }
    }
}
