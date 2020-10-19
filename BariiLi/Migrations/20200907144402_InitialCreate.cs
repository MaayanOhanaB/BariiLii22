using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BariiLi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalTeam",
                columns: table => new
                {
                    MTId = table.Column<string>(maxLength: 9, nullable: false),
                    fullName = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    specialization = table.Column<string>(nullable: true),
                    availability = table.Column<DateTime>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    previousExprience = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalTeam", x => x.MTId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    patientId = table.Column<string>(maxLength: 9, nullable: false),
                    fullName = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    typeOfPain = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.patientId);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentSystems",
                columns: table => new
                {
                    typeOfPain = table.Column<string>(nullable: false),
                    MTId = table.Column<int>(nullable: false),
                    patientId = table.Column<int>(nullable: false),
                    availabilityQueues = table.Column<DateTime>(nullable: false),
                    medicalTeamMTId = table.Column<string>(nullable: true),
                    patientspatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSystems", x => x.typeOfPain);
                    table.ForeignKey(
                        name: "FK_AppointmentSystems_MedicalTeam_medicalTeamMTId",
                        column: x => x.medicalTeamMTId,
                        principalTable: "MedicalTeam",
                        principalColumn: "MTId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppointmentSystems_Patients_patientspatientId",
                        column: x => x.patientspatientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSystems_medicalTeamMTId",
                table: "AppointmentSystems",
                column: "medicalTeamMTId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSystems_patientspatientId",
                table: "AppointmentSystems",
                column: "patientspatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentSystems");

            migrationBuilder.DropTable(
                name: "MedicalTeam");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
