using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turismo_EntityF.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtRegisterCity = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DtRegisterAddress = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressClientId = table.Column<int>(type: "int", nullable: false),
                    DtRegisterClient = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Address_AddressClientId",
                        column: x => x.AddressClientId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameHotel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressHotelId = table.Column<int>(type: "int", nullable: false),
                    DtRegisterHotel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValueHotel = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_Address_AddressHotelId",
                        column: x => x.AddressHotelId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    DestinyId = table.Column<int>(type: "int", nullable: false),
                    ClientTicketId = table.Column<int>(type: "int", nullable: false),
                    DateTicket = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValueTicket = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Address_DestinyId",
                        column: x => x.DestinyId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ticket_Address_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ticket_Client_ClientTicketId",
                        column: x => x.ClientTicketId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelPackageId = table.Column<int>(type: "int", nullable: false),
                    TicketPackageId = table.Column<int>(type: "int", nullable: false),
                    DtRegisterPackage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValuePackage = table.Column<double>(type: "float", nullable: false),
                    ClientPackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_Client_ClientPackageId",
                        column: x => x.ClientPackageId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Package_Hotel_HotelPackageId",
                        column: x => x.HotelPackageId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Package_Ticket_TicketPackageId",
                        column: x => x.TicketPackageId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_AddressClientId",
                table: "Client",
                column: "AddressClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_AddressHotelId",
                table: "Hotel",
                column: "AddressHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_ClientPackageId",
                table: "Package",
                column: "ClientPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_HotelPackageId",
                table: "Package",
                column: "HotelPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_TicketPackageId",
                table: "Package",
                column: "TicketPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ClientTicketId",
                table: "Ticket",
                column: "ClientTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DestinyId",
                table: "Ticket",
                column: "DestinyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OriginId",
                table: "Ticket",
                column: "OriginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
