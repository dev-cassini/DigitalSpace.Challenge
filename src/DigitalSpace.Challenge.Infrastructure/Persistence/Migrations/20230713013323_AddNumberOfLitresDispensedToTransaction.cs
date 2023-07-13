using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberOfLitresDispensedToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfLitresDispensed",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfLitresDispensed",
                table: "Transactions");
        }
    }
}
