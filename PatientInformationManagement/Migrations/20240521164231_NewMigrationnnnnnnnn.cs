using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientInformationManagement.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationnnnnnnnn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NCD_Details",
                table: "NCD_Details");

            migrationBuilder.DropIndex(
                name: "IX_NCD_Details_PatientID",
                table: "NCD_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergies_Details",
                table: "Allergies_Details");

            migrationBuilder.DropIndex(
                name: "IX_Allergies_Details_PatientID",
                table: "Allergies_Details");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "NCD_Details");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Allergies_Details");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Patients",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "NCDID",
                table: "NCDs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DiseaseID",
                table: "Diseases",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "AllergiesID",
                table: "Allergies",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NCD_Details",
                table: "NCD_Details",
                columns: new[] { "PatientID", "NCDID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergies_Details",
                table: "Allergies_Details",
                columns: new[] { "PatientID", "AllergiesID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NCD_Details",
                table: "NCD_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergies_Details",
                table: "Allergies_Details");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Patients",
                newName: "PatientID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "NCDs",
                newName: "NCDID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Diseases",
                newName: "DiseaseID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Allergies",
                newName: "AllergiesID");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "NCD_Details",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Allergies_Details",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NCD_Details",
                table: "NCD_Details",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergies_Details",
                table: "Allergies_Details",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_PatientID",
                table: "NCD_Details",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Details_PatientID",
                table: "Allergies_Details",
                column: "PatientID");
        }
    }
}
