using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoinoa.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoMonitoramento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id1",
                table: "Monitoramento");

            migrationBuilder.DropColumn(
                name: "Id2",
                table: "Monitoramento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id1",
                table: "Monitoramento",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id2",
                table: "Monitoramento",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
