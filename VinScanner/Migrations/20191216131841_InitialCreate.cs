using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VinScanner.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    DealerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserNmae = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.DealerId);
                });

            migrationBuilder.CreateTable(
                name: "VechileDetails",
                columns: table => new
                {
                    VechileDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Plate = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Vin = table.Column<string>(nullable: true),
                    Engine = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VechileDetails", x => x.VechileDetailsId);
                    table.ForeignKey(
                        name: "FK_VechileDetails_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VechileDetails_ClientId",
                table: "VechileDetails",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "VechileDetails");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
