using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.EntityFramework.SqlServer.Migrations
{
    public partial class AddOrderIdToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Reservations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Reservations");
        }
    }
}
