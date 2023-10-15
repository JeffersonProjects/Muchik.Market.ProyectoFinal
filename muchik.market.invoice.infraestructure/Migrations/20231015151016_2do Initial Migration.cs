using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace muchik.market.invoice.infraestructure.Migrations
{
    public partial class _2doInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "invoice",
               columns: table => new
               {
                   id_invoice = table.Column<int>(type: "integer", nullable: false)
                       .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                   amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                   state = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_invoice", x => x.id_invoice);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
             name: "invoice");
        }
    }
}
