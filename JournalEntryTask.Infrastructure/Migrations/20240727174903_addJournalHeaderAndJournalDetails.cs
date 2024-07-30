using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JournalEntryTask.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addJournalHeaderAndJournalDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountsChart",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FK_Transaction_Type_ID = table.Column<short>(type: "smallint", nullable: false),
                    Allow_Entry = table.Column<bool>(type: "bit", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    User_ID = table.Column<long>(type: "bigint", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Parent_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parent_Number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Chart_Level_Depth = table.Column<short>(type: "smallint", nullable: false),
                    FK_Cost_Center_Type_ID = table.Column<short>(type: "smallint", nullable: true),
                    Branch_ID = table.Column<long>(type: "bigint", nullable: false),
                    Org_ID = table.Column<long>(type: "bigint", nullable: false),
                    FK_Work_Fields_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    noOfChilds = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accounts__3214EC2748817F42", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JournalHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JournalHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalDetails_AccountsChart_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountsChart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalDetails_JournalHeaders_JournalHeaderId",
                        column: x => x.JournalHeaderId,
                        principalTable: "JournalHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalDetails_AccountId",
                table: "JournalDetails",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalDetails_JournalHeaderId",
                table: "JournalDetails",
                column: "JournalHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalDetails");

            migrationBuilder.DropTable(
                name: "AccountsChart");

            migrationBuilder.DropTable(
                name: "JournalHeaders");
        }
    }
}
