using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.Migrations
{
  public partial class InitialCreate : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "Contacts",
        columns: table => new
        {
          Id = table.Column<int>(nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
          FirstName = table.Column<string>(maxLength: 50),
          LastName = table.Column<string>(maxLength: 50),
          NickName = table.Column<string>(maxLength: 50, nullable: true),
          BirthDate = table.Column<DateTime>(nullable: true),
          Organization = table.Column<string>(maxLength: 100, nullable: true),
          Role = table.Column<string>(maxLength: 50, nullable: true),
          Notes = table.Column<string>(maxLength: 255, nullable: true),
          Favorite = table.Column<bool>(defaultValue: false),
          CreatedAt = table.Column<DateTime>(defaultValue: DateTime.Now),
          UpdatedAt = table.Column<DateTime>(defaultValue: DateTime.Now)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Contacts", x => x.Id);
        });

      migrationBuilder.CreateTable(
        name: "Phones",
        columns: table => new
        {
          Id = table.Column<int>(nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
          PhoneNumber = table.Column<string>(maxLength: 15),
          CreatedAt = table.Column<DateTime>(defaultValue: DateTime.Now),
          UpdatedAt = table.Column<DateTime>(defaultValue: DateTime.Now),
          ContactId = table.Column<int>()
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Phones", x => x.Id);
          table.ForeignKey(
                    name: "FK_Phones_Contacts_ContactId",
                    column: x => x.ContactId,
                    principalTable: "Contacts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
        });

      migrationBuilder.CreateTable(
        name: "Emails",
        columns: table => new
        {
          Id = table.Column<int>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
          EmailAddress = table.Column<string>(maxLength: 120),
          CreatedAt = table.Column<DateTime>(defaultValue: DateTime.Now),
          UpdatedAt = table.Column<DateTime>(defaultValue: DateTime.Now),
          ContactId = table.Column<int>()
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Emails", x => x.Id);
          table.ForeignKey(
            name: "FK_Emails_Contacts_ContactId",
            column: x => x.ContactId,
            principalTable: "Contacts",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
        });

      migrationBuilder.CreateIndex(
        name: "UQ_Contacts_Name",
        table: "Contacts",
        columns: new[] { "FirstName", "LastName" },
        unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_Phones_ContactId",
          table: "Phones",
          column: "ContactId");

      migrationBuilder.CreateIndex(
        name: "UQ_Phones_PhoneNumber",
        table: "Phones",
        column: "PhoneNumber",
        unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_Emails_ContactId",
          table: "Emails",
          column: "ContactId");

      migrationBuilder.CreateIndex(
        name: "UQ_Emails_EmailAddress",
        table: "Emails",
        column: "EmailAddress",
        unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(name: "Emails");
      migrationBuilder.DropTable(name: "Phones");
      migrationBuilder.DropTable(name: "Contacts");
    }
  }
}
