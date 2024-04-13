using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADSProject.Migrations
{
    /// <inheritdoc />
    public partial class Profesores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Porfesores",
                table: "Porfesores");

            migrationBuilder.RenameTable(
                name: "Porfesores",
                newName: "Profesores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores",
                column: "IdProfesor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores");

            migrationBuilder.RenameTable(
                name: "Profesores",
                newName: "Porfesores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Porfesores",
                table: "Porfesores",
                column: "IdProfesor");
        }
    }
}
