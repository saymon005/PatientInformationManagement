using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientInformationManagement.Migrations
{
    /// <inheritdoc />
    public partial class seedEpilepsies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_epilespsies",
                table: "epilespsies");

            migrationBuilder.RenameTable(
                name: "epilespsies",
                newName: "Epilespsies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Epilespsies",
                table: "Epilespsies",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Epilespsies",
                table: "Epilespsies");

            migrationBuilder.RenameTable(
                name: "Epilespsies",
                newName: "epilespsies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_epilespsies",
                table: "epilespsies",
                column: "Id");
        }
    }
}
