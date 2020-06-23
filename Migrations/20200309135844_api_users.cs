using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BSSLNCSApi.Migrations
{
    public partial class api_users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActNo = table.Column<string>(nullable: true),
                    ActPeriod = table.Column<string>(nullable: true),
                    ActYear = table.Column<string>(nullable: true),
                    ActDate = table.Column<DateTime>(nullable: true),
                    InvoiceAmount = table.Column<string>(nullable: true),
                    CrValue = table.Column<string>(nullable: true),
                    CustCode = table.Column<string>(nullable: true),
                    TransAmount = table.Column<string>(nullable: true),
                    RecNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTransactions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIUsers");

            migrationBuilder.DropTable(
                name: "MemberTransactions");
        }
    }
}
