using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecourts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecourts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    FuelType = table.Column<int>(type: "integer", nullable: false),
                    FuelLevel = table.Column<int>(type: "integer", nullable: false),
                    TankCapacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lanes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ForecourtId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lanes_Forecourts_ForecourtId",
                        column: x => x.ForecourtId,
                        principalTable: "Forecourts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pumps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LaneId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pumps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pumps_Lanes_LaneId",
                        column: x => x.LaneId,
                        principalTable: "Lanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateTimeCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateTimeFilling = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateTimeCompleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PumpId = table.Column<Guid>(type: "uuid", nullable: true),
                    ForecourtId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Forecourts_ForecourtId",
                        column: x => x.ForecourtId,
                        principalTable: "Forecourts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Pumps_PumpId",
                        column: x => x.PumpId,
                        principalTable: "Pumps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lanes_ForecourtId",
                table: "Lanes",
                column: "ForecourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_LaneId",
                table: "Pumps",
                column: "LaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ForecourtId",
                table: "Transactions",
                column: "ForecourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PumpId",
                table: "Transactions",
                column: "PumpId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_VehicleId",
                table: "Transactions",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Pumps");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Lanes");

            migrationBuilder.DropTable(
                name: "Forecourts");
        }
    }
}
