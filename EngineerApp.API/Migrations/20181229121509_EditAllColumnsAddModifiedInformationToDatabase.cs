using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EngineerApp.API.Migrations
{
    public partial class EditAllColumnsAddModifiedInformationToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "ModiefiedBy",
                table: "Users",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "IncidentsHistory",
                newName: "IncidentType");

            migrationBuilder.RenameColumn(
                name: "Oct4_Card",
                table: "Cards",
                newName: "CardNumber4");

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Presences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Presences",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Localizations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Localizations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Departments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Departments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "CardReaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CardReaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Presences");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Presences");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Localizations");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Localizations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CardReaders");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CardReaders");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Users",
                newName: "ModiefiedBy");

            migrationBuilder.RenameColumn(
                name: "IncidentType",
                table: "IncidentsHistory",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "CardNumber4",
                table: "Cards",
                newName: "Oct4_Card");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Cards",
                nullable: true);
        }
    }
}
