using Microsoft.EntityFrameworkCore.Migrations;

namespace rolesDemoSSD.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IPNs",
                columns: table => new
                {
                    paymentID = table.Column<string>(type: "TEXT", nullable: false),
                    custom = table.Column<string>(type: "TEXT", nullable: true),
                    cart = table.Column<string>(type: "TEXT", nullable: true),
                    create_time = table.Column<string>(type: "TEXT", nullable: true),
                    payerID = table.Column<string>(type: "TEXT", nullable: true),
                    payerFirstName = table.Column<string>(type: "TEXT", nullable: true),
                    payerLastName = table.Column<string>(type: "TEXT", nullable: true),
                    payerMiddleName = table.Column<string>(type: "TEXT", nullable: true),
                    payerEmail = table.Column<string>(type: "TEXT", nullable: true),
                    payerCountryCode = table.Column<string>(type: "TEXT", nullable: true),
                    payerStatus = table.Column<string>(type: "TEXT", nullable: true),
                    amount = table.Column<string>(type: "TEXT", nullable: true),
                    currency = table.Column<string>(type: "TEXT", nullable: true),
                    intent = table.Column<string>(type: "TEXT", nullable: true),
                    paymentMethod = table.Column<string>(type: "TEXT", nullable: true),
                    paymentState = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPNs", x => x.paymentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPNs");
        }
    }
}
