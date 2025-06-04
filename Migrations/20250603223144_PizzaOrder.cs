using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaBE.Migrations
{
    /// <inheritdoc />
    public partial class PizzaOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaOrders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PizzaOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaItems_PizzaOrders_PizzaOrderId",
                        column: x => x.PizzaOrderId,
                        principalTable: "PizzaOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackingSteps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    PizzaOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingSteps_PizzaOrders_PizzaOrderId",
                        column: x => x.PizzaOrderId,
                        principalTable: "PizzaOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaItems_PizzaOrderId",
                table: "PizzaItems",
                column: "PizzaOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrders_UserId",
                table: "PizzaOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingSteps_PizzaOrderId",
                table: "TrackingSteps",
                column: "PizzaOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaItems");

            migrationBuilder.DropTable(
                name: "TrackingSteps");

            migrationBuilder.DropTable(
                name: "PizzaOrders");
        }
    }
}
